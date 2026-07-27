using System;

namespace AfterOCP
{
    /// <summary>
    /// Represents a Circle shape
    /// This class follows OCP - it's closed for modification but open for extension
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Gets or sets the radius of the circle
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the Circle class
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculates the area of the circle
        /// </summary>
        /// <returns>The area of the circle (π * r²)</returns>
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}