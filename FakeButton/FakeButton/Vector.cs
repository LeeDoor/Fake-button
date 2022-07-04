using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeButton
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector Invert()
        {
            X = -X;
            Y = -Y;

            return this;
        }

        public Vector Module()
        {
            X = Math.Abs(X);
            Y = Math.Abs(Y);

            return this;
        }
    }
}
