using System; // Потрібен для DateTime
using System.Collections.Generic;

namespace ConstructorApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Untitled Project"; 
        public string? Description { get; set; } = "No description provided.";
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public string UserId { get; set; } 
        public ApplicationUser? User { get; set; }
        
        public ICollection<Scene> Scenes { get; set; } = new List<Scene>();
        
        public ProjectSetting? Settings { get; set; }
    }
}
