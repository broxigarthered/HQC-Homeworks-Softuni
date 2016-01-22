using System;

namespace Abstraction
{
    abstract class Figure
    {
        #region fields
        private double radius;
        private double width;
        private double height;
        #endregion

        #region constructors
        protected Figure()
        {
        }

        protected Figure(double radius)
        {
            this.Radius = radius;
        }

        protected Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        #endregion

        #region properties

        public virtual double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public virtual double Height {
            get { return this.height; }
            set { this.height = value; }
        }

        public virtual double Radius
        {
            get { return this.radius; }
            private set { this.radius = value; }
        }
        #endregion

        #region methods
        public virtual double CalcPerimeter()
        {
            throw new NotImplementedException();
        }

        public virtual double CalcSurface()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
