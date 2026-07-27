namespace AfterOCP
{
    /// <summary>
    /// Interface for all shapes
    /// This follows OCP by allowing new shapes without modifying existing code
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Calculates the area of the shape
        /// </summary>
        /// <returns>The area of the shape</returns>
        double CalculateArea();
    }
}