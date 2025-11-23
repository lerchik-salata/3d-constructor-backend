using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload; 
using System.Threading;

namespace ConstructorApi.Services
{
    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly DriveService _driveService;
        private readonly string _folderId;
        private readonly IConfiguration _config;

        public GoogleDriveService(IConfiguration config)
        {
            _config = config; 
            
            var clientSecrets = new ClientSecrets
            {
                ClientId = config["GD_CLIENT_ID"],
                ClientSecret = config["GD_CLIENT_SECRET"]
            };

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = clientSecrets,
                Scopes = new[] { DriveService.ScopeConstants.DriveFile }
            });

            var credential = new UserCredential(
                flow,
                "user",
                new TokenResponse { RefreshToken = config["GD_REFRESH_TOKEN"] }
            );

            credential.RefreshTokenAsync(CancellationToken.None).Wait();

            _driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "ConstructorApi"
            });

            _folderId = config["GD_FOLDER_ID"] 
                ?? throw new Exception("GoogleDrive:FolderId is missing in configuration");
        }

        public async Task<Stream> DownloadFileStreamAsync(string fileId)
            {
                var url = $"https://drive.google.com/uc?export=download&id={fileId}";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStreamAsync();
            }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
             var fileMeta = new Google.Apis.Drive.v3.Data.File
            {
                Name = file.FileName,
                Parents = new List<string> { _folderId }
            };

            using var stream = file.OpenReadStream();

            var request = _driveService.Files.Create(fileMeta, stream, file.ContentType);
            request.Fields = "id, webViewLink"; 
            
            var result = await request.UploadAsync();

            if (result.Status == UploadStatus.Completed)
            {
                var fileId = request.ResponseBody.Id;
                
                try
                {
                    var permission = _driveService.Permissions.Create(new Google.Apis.Drive.v3.Data.Permission
                    {
                        Type = "anyone",
                        Role = "reader",
                    }, fileId);
                    await permission.ExecuteAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to set file permissions.", ex);
                }

                return $"https://drive.google.com/thumbnail?id={fileId}&sz=w800-h800";
            }
            else if (result.Status == UploadStatus.Failed)
            {
                throw new Exception($"Upload failed. Reason: {result.Exception?.Message ?? "Unknown failure."}");
            }
            else
            {
                 throw new Exception($"Upload failed. Status: {result.Status}.");
            }
        }
    }

    public interface IGoogleDriveService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<Stream> DownloadFileStreamAsync(string fileId);
    }
}