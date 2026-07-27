namespace AfterOCP
{
    /// <summary>
    /// Represents a Rectangle shape
    /// This class follows OCP - it's closed for modification but open for extension
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
        /// <returns>The area of the rectangle (width * height)</returns>
        public double CalculateArea()
        {
            return Width * Height;
        }
    }
}