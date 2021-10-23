using System;
using System.Dynamic;

namespace ClassBoxData
{
    public class Box
    {
        private const string EXC_MESS = "{0} cannot be zero or negative.";
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double length;
        private double width;
        private double height;
        public double Length
        {
            get => this.length;
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(EXC_MESS, nameof(this.Length)));
                }
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(EXC_MESS, nameof(this.Width)));
                }
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(EXC_MESS, nameof(this.Height)));
                }
            }
        }

        public double CalculateArea(double length, double width, double height)
        {
            var area = 2 * length * width + 2 * length * height + 2 * width * height;

            return area;
        }
        public double CalculateLateralArea(double length, double width, double height)
        {
            var lateralArea = 2 * length * height + 2 * width * height;

            return lateralArea;
        }
        public double CalculateVolume(double length, double width, double height)
        {
            var volume = length * width * height;

            return volume;
        }
    }
}
