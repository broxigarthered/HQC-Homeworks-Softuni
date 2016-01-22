using System;

namespace Abstraction
{
    class Circle : Figure
    {
        #region constructors
        public Circle()
        {
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        #endregion

        #region properties

        public double Radius
        {
            get; set;
        }

        #endregion

        #region methods
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
        #endregion
    }
}
