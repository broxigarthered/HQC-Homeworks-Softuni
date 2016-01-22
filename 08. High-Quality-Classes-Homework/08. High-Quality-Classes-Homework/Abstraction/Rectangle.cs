using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        #region constructors
        public Rectangle()
            : base(0, 0)
        {
        }

        public Rectangle(double width, double height)
            : base(width, height)
        {
            this.Width = width;
            this.Height = height;
        }
        #endregion

        #region properties

        public override double Width
        {
            get; set;
        }

        public override double Height
        {
            get; set;
        }

        public override double Radius
        {
            get
            {
                throw new ArgumentException("Rectangle does not have Radius");
            }
            set
            {
                throw new ArgumentException("Rectangle does not have Radius");
            }
        }
        #endregion

        #region methods
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
        #endregion
    }
}
