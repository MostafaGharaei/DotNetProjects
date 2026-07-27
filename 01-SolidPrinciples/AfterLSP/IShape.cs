namespace AfterLSP
{
    /// <summary>
    /// Interface for all shapes
    /// This follows LSP by defining a contract that all shapes must implement
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