using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Mvc;
using ConstructorApi.Services;
using Microsoft.AspNetCore.Cors;

namespace ConstructorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly IGoogleDriveService _driveService;

        public ProxyController(IGoogleDriveService driveService)
        {
            _driveService = driveService;
        }

    [HttpGet("texture/{fileId}")]
    [EnableCors("AllowReactApp")]
    public async Task<IActionResult> GetTexture(string fileId)
    {
        try
        {
            var stream = await _driveService.DownloadFileStreamAsync(fileId);
            if (stream == null)
                return NotFound();

            stream.Position = 0;
            return File(stream, "image/jpeg", enableRangeProcessing: true);
        }
        catch (Google.GoogleApiException gEx) when (gEx.HttpStatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            return Forbid("Access to the file is forbidden. Check Google Drive permissions.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    }
}
