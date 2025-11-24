using ConstructorApi.Models.Shapes;
using System;

namespace ConstructorApi.Factories
{
    public static class ShapeFactory
    {
        public static IShape CreateShape(string type)
        {
            return type.ToLower() switch
            {
                "cube" => new Cube(),
                "sphere" => new Sphere(),
                "cylinder" => new Cylinder(),
                "cone" => new Cone(),
                "torus" => new Torus(),
                "plane" => new Plane(),
                _ => throw new ArgumentException($"Unknown shape type: {type}")
            };
        }
    }
}
