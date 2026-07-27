using System;

namespace BeforeOCP
{
    /// <summary>
    /// Represents different types of shapes
    /// This class violates OCP because it needs modification to add new shapes
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Gets or sets the type of the shape
        /// </summary>
        public ShapeType Type { get; set; }

        /// <summary>
        /// Gets or sets the radius for Circle
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets the width for Rectangle
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height for Rectangle
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the side length for Square
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Calculates the area of the shape
        /// This violates OCP because adding a new shape requires modifying this method
        /// </summary>
        /// <returns>The area of the shape</returns>
        public double CalculateArea()
        {
            switch (Type)
            {
                case ShapeType.Circle:
                    return Math.PI * Radius * Radius;
                case ShapeType.Rectangle:
                    return Width * Height;
                case ShapeType.Square:
                    return Side * Side;
                default:
                    throw new ArgumentException("Unsupported shape type");
            }
        }
    }

    /// <summary>
    /// Enum representing different shape types
    /// </summary>
    public enum ShapeType
    {
        Circle,
        Rectangle,
        Square
    }
}