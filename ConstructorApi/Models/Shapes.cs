using System.Collections.Generic;

namespace ConstructorApi.Models.Shapes
{
    public class Cube : IShape
    {
        public string Type => "cube";
        public Dictionary<string, float> Params => new()
        {
            { "width", 1f },
            { "height", 1f },
            { "depth", 1f }
        };
    }

    public class Sphere : IShape
    {
        public string Type => "sphere";
        public Dictionary<string, float> Params => new()
        {
            { "radius", 0.5f }
        };
    }

    public class Cylinder : IShape
    {
        public string Type => "cylinder";
        public Dictionary<string, float> Params => new()
        {
            { "radius", 0.5f },
            { "height", 1f }
        };
    }

    public class Cone : IShape
    {
        public string Type => "cone";
        public Dictionary<string, float> Params => new()
        {
            { "radius", 0.5f },
            { "height", 1f }
        };
    }

    public class Torus : IShape
    {
        public string Type => "torus";
        public Dictionary<string, float> Params => new()
        {
            { "radius", 1f },
            { "tube", 0.4f }
        };
    }

    public class Plane : IShape
    {
        public string Type => "plane";
        public Dictionary<string, float> Params => new()
        {
            { "width", 2f },
            { "height", 2f }
        };
    }

    public interface IShape
    {
        string Type { get; }
        Dictionary<string, float> Params { get; }
    }
}
