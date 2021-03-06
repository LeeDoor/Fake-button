using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeButton
{
	/// <summary>
	/// struct means vector
	/// </summary>
	public struct Vector
	{
		/// <summary>
		/// X position of vector
		/// </summary>
		public double X { get; set; }

		/// <summary>
		/// Y position of vector
		/// </summary>
		public double Y { get; set; }

		/// <summary>
		/// property returns length of vector
		/// </summary>
		public double Length { get => Math.Sqrt(Math.Pow(Math.Abs(X), 2) + Math.Pow(Math.Abs(Y), 2)); }

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="x">x coord</param>
		/// <param name="y">y coord</param>
		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}
		
		/// <summary>
		/// vector inverts its coords
		/// </summary>
		/// <returns>return itself</returns>
		public Vector Invert()
		{
			X = -X;
			Y = -Y;

			return this;
		}

		/// <summary>
		/// modules its coords
		/// </summary>
		/// <returns>return itself</returns>
		public Vector Module()
		{
			X = Math.Abs(X);
			Y = Math.Abs(Y);

			return this;
		}

		/// <summary>
		/// function normalize vector
		/// </summary>
		/// <returns>returns itself</returns>
		public Vector Normalize()
		{
			double ls = X * X + Y * Y;
			double invNorm = (double)100.0d / Math.Sqrt(ls);

			X *= invNorm;
			Y *= invNorm;
			return this;
		}

		/// <summary>
		/// gets vector between two points
		/// </summary>
		/// <param name="point">first point</param>
		/// <param name="point2">second point</param>
		/// <returns>returns vector</returns>
		public static Vector GetVector(Point point, Point point2)
		{
			return new Vector()
			{
				X = point2.X - point.X,
				Y = point2.Y - point.Y
			};
		}

        #region overrided operators
        public static Vector operator +(Vector a, Vector b)
		{
			return new Vector(a.X + b.X, a.Y + b.Y);
		}
		public static Vector operator *(Vector a, int b)
		{
			return new Vector(a.X * b, a.Y * b);
		}
		public static Vector operator /(Vector a, int b)
		{
			return new Vector(a.X / b, a.Y / b);
		}
		#endregion

	}
}