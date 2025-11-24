using System;

namespace ConstructorApi.Models.Shapes
{
    public interface IShape
    {
        string Type { get; }
        float[] DefaultDimensions { get; }
        string DefaultColor { get; }
    }

    public class Cube : IShape
    {
        public string Type => "cube";
        public float[] DefaultDimensions => new float[] { 1f, 1f, 1f };
        public string DefaultColor => "hotpink";
    }

    public class Sphere : IShape
    {
        public string Type => "sphere";
        public float[] DefaultDimensions => new float[] { 0.5f };
        public string DefaultColor => "#3C78D8";
    }

    public class Cylinder : IShape
    {
        public string Type => "cylinder";
        public float[] DefaultDimensions => new float[] { 0.5f, 1f };
        public string DefaultColor => "#6AA84F";
    }

    public class Cone : IShape
    {
        public string Type => "cone";
        public float[] DefaultDimensions => new float[] { 0.5f, 1f };
        public string DefaultColor => "#FFB347";
    }

    public class Torus : IShape
    {
        public string Type => "torus";
        public float[] DefaultDimensions => new float[] { 1f, 0.4f };
        public string DefaultColor => "#9B59B6";
    }

    public class Plane : IShape
    {
        public string Type => "plane";
        public float[] DefaultDimensions => new float[] { 2f, 2f };
        public string DefaultColor => "#95A5A6";
    }
}
