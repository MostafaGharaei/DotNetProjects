using System;

namespace BeforeLSP
{
    /// <summary>
    /// Represents a Rectangle
    /// This class violates LSP when extended by Square
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Gets or sets the width of the rectangle
        /// </summary>
        public virtual double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle
        /// </summary>
        public virtual double Height { get; set; }

        /// <summary>
        /// Calculates the area of the rectangle
        /// </summary>
        /// <returns>The area of the rectangle</returns>
        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    /// <summary>
    /// Represents a Square (which is a Rectangle in geometry)
    /// This violates LSP because a Square cannot be substituted for a Rectangle
    /// </summary>
    public class Square : Rectangle
    {
        /// <summary>
        /// Overrides the Width property to maintain square constraint
        /// This violates LSP - changing behavior of base class
        /// </summary>
        public override double Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        /// <summary>
        /// Overrides the Height property to maintain square constraint
        /// This violates LSP - changing behavior of base class
        /// </summary>
        public override double Height
        {
            get => base.Height;
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}