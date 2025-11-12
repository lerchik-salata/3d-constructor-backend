using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConstructorApi.Models
{
    public class Scene
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Untitled Scene"; 
        
        public ICollection<SceneObject> Objects { get; set; } = new List<SceneObject>();

        public int ProjectId { get; set; }

        [JsonIgnore]
        public Project? Project { get; set; }
    }
}