using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeButton
{
	/// <summary>
	/// class ordered to move button if cursor is near
	/// </summary>
	public class ButtonMove
	{
		/// <summary>
		/// link on button object
		/// </summary>
		public Button button { get; set; }

		/// <summary>
		/// main form
		/// </summary>
		public Form1 form { get; set; }

		/// <summary>
		/// property to get middle point of button
		/// </summary>
		private Point Midpoint { get => new Point()
		{
			X = button.Location.X + button.Width / 2,
			Y = button.Location.Y + button.Height / 2
		};
		}

		/// <summary>
		/// variable gets info about button reaction distance
		/// </summary>
		public readonly double reacDist = 100d;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="button">button object we operate with</param>
		/// <param name="form">main form</param>
		public ButtonMove(Button button, Form1 form)
        {
            this.button = button;
            this.form = form;
        }

        /// <summary>
        /// func when button wants to move out of cursor
        /// </summary>
        /// <param name="control">button control</param>
        public void MoveOutwards()
		{
			if (GetDistance(form.InMousePosition) > reacDist)
				return;

			Vector moving;
			if (VecToClosestBorder(out Vector vectorA))
            {
				vectorA.Normalize();
				Vector vectorB = Vector.GetVector(Midpoint, form.InMousePosition).Normalize();
				moving = (vectorA + vectorB).Invert();
            }
            else
            {
				moving = Vector.GetVector(Midpoint, form.InMousePosition).Invert() / 2;
            }
			ApplyMovement(moving);
            if (IsOutOfRange())
            {
				ApplyMovement(Vector.GetVector(Midpoint, form.InMousePosition).Normalize()*3);
            }
			form.Invalidate();
		}

		/// <summary>
		/// function checks if button out of bounds
		/// </summary>
		/// <returns>returns true if is out</returns>
		private bool IsOutOfRange()
        {
			Point pos = Midpoint;
			Rectangle border = form.ButtonBorder;
			return !(border.X <= pos.X && pos.X <= border.X+border.Width &&
				border.Y <= pos.Y && pos.Y <= border.Y + border.Height);
        }

        /// <summary>
        /// gets distance between point and control
        /// </summary>
        /// <param name="point">point (mouse position)</param>
        /// <param name="control">control (button)</param>
        /// <returns>returns double distance</returns>
        private double GetDistance(Point point)
		{
			Point point2 = Midpoint;
			Vector distance = Vector.GetVector(point, point2).Module();
			return Math.Sqrt(Math.Pow(distance.X, 2) + Math.Pow(distance.Y, 2));
		}

		/// <summary>
		/// applies vector to button coordinates
		/// </summary>
		/// <param name="control">control button</param>
		/// <param name="vector">vector</param>
		private void ApplyMovement(Vector vector)
		{
			button.Location = new Point()
			{
				X = button.Location.X + (int)vector.X,
				Y = button.Location.Y + (int)vector.Y
			};
		}

		/// <summary>
		/// gets vector from button to closest border of screen
		/// </summary>
		/// <param name="res">output parameter - vector</param>
		/// <returns></returns>
		public bool VecToClosestBorder(out Vector res)
		{
			List<Vector> distances = new List<Vector>();
			Rectangle border = form.ButtonBorder;
			Point midpoint = Midpoint;

			distances.Add(new Vector(0, border.Y - midpoint.Y));
			distances.Add(new Vector(border.X + border.Width - midpoint.X, 0));
			distances.Add(new Vector(0, border.Y + border.Height - midpoint.Y));
			distances.Add(new Vector(border.X - midpoint.X, 0));

			res = distances.OrderBy(n => n.Length).First();

			return res.Length <= reacDist;
		}
	}
}


