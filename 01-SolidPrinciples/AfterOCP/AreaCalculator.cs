using System.Collections.Generic;
using System.Linq;

namespace AfterOCP
{
    /// <summary>
    /// Calculates total area for a collection of shapes
    /// This class follows OCP - it works with any IShape implementation
    /// </summary>
    public class AreaCalculator
    {
        /// <summary>
        /// Calculates the total area of all shapes in the collection
        /// </summary>
        /// <param name="shapes">Collection of shapes</param>
        /// <returns>Total area of all shapes</returns>
        public double CalculateTotalArea(IEnumerable<IShape> shapes)
        {
            if (shapes == null || !shapes.Any())
                return 0;

            return shapes.Sum(shape => shape.CalculateArea());
        }
    }
}