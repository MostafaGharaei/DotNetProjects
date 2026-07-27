namespace AfterLSP
{
    /// <summary>
    /// Represents a Rectangle
    /// This class follows LSP - it implements IShape correctly
    /// </summary>
    public class Rectangle : IShape
    {
        /// <summary>
        /// Gets or sets the width of the rectangle
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the Rectangle class
        /// </summary>
        /// <param name="width">The width of the rectangle</param>
        /// <param name="height">The height of the rectangle</param>
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Calculates the area of the rectangle
        /// </summary>
        /// <returns>The area of the rectangle</returns>
        public double CalculateArea()
        {
            return Width * Height;
        }
    }
}