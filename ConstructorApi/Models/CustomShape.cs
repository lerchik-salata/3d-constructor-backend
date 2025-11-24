using System.Text.Json;
using System.ComponentModel.DataAnnotations.Schema;

public class CustomShape : BaseEntity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }

    [Column(TypeName = "jsonb")] 
    public string ParamsJson { get; set; } = "{}";

    [NotMapped]
    public Dictionary<string, float> Params
    {
        get => JsonSerializer.Deserialize<Dictionary<string, float>>(ParamsJson) ?? new Dictionary<string, float>();
        set => ParamsJson = JsonSerializer.Serialize(value);
    }
}
