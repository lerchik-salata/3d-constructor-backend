namespace ConstructorApi.DTOs.CustomShape
{
    public class CustomShapeDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Color { get; set; } = null!;
        public Dictionary<string, float> Params { get; set; } = new();
    }
}
