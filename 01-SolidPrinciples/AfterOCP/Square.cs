namespace AfterOCP
{
    /// <summary>
    /// Represents a Square shape
    /// This class follows OCP - it's closed for modification but open for extension
    /// </summary>
    public class Square : IShape
    {
        /// <summary>
        /// Gets or sets the side length of the square
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Initializes a new instance of the Square class
        /// </summary>
        /// <param name="side">The side length of the square</param>
        public Square(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Calculates the area of the square
        /// </summary>
        /// <returns>The area of the square (side * side)</returns>
        public double CalculateArea()
        {
            return Side * Side;
        }
    }
}