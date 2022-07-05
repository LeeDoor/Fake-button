using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeButton
{
	public class ButtonMove
	{
		public Button button { get; set; }
		public Form1 form { get; set; }

		/// <summary>
		/// variable gets info about button reaction distance
		/// </summary>
		public readonly double reacDist = 100d;
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
			{
				return;
			}
			Vector backVector = Vector.GetVector(GetControlMidpoint(), form.InMousePosition).Invert();
			ApplyMovement(backVector);

			FormSides? side = IsOutOfRange();

			if (side != null)
			{
				var point = GetClosestBorderPoint(side.Value);
				ApplyMovement(Vector.GetVector(GetControlMidpoint(), point));
			}
			form.Invalidate();
		}

		/// <summary>
		/// gets closest point which is enough far from cursor
		/// </summary>
		/// <param name="side">side, near you are</param>
		/// <param name="control">control button</param>
		/// <param name="space">recursivly getting space to count</param>
		/// <returns>returns far point</returns>
		private Point GetClosestBorderPoint(FormSides side, int space = 0)
		{
			if (space >= reacDist / 2)
				return new Point()
				{
					X = form.Width / 2,
					Y = form.Height / 2
				};
			Point point = new();
			switch (side)
			{
				case FormSides.Left:
					point = new Point()
					{
						X = 0,
						Y = button.Location.Y + space
					};
					break;
				case FormSides.Right:
					point = new Point()
					{
						X = form.Width,
						Y = button.Location.Y + space
					};
					break;
				case FormSides.Bottom:
					point = new Point()
					{
						X = button.Location.X + space,
						Y = form.Height
					};
					break;
				case FormSides.Top:
					point = new Point()
					{
						X = button.Location.X + space,
						Y = 0
					};
					break;

			}
			if (GetDistance(form.InMousePosition, point) > reacDist)
			{
				return point;
			}
			else return GetClosestBorderPoint(side, -(space * +5));
		}

		/// <summary>
		/// gets distance between point and control
		/// </summary>
		/// <param name="point">point (mouse position)</param>
		/// <param name="control">control (button)</param>
		/// <returns>returns double distance</returns>
		private double GetDistance(Point point)
		{
			Point point2 = GetControlMidpoint();
			Vector distance = Vector.GetVector(point, point2).Module();
			return Math.Sqrt(Math.Pow(distance.X, 2) + Math.Pow(distance.Y, 2));
		}

		/// <summary>
		/// gets distance between point and control
		/// </summary>
		/// <param name="point">point (mouse position)</param>
		/// <param name="point2">second point (screen borders)</param>
		/// <returns>returns double distance</returns>
		private double GetDistance(Point point, Point point2)
		{
			;
			Vector distance = Vector.GetVector(point, point2).Module();
			return Math.Sqrt(Math.Pow(distance.X, 2) + Math.Pow(distance.Y, 2));
		}

		/// <summary>
		/// gets middle point of control to correctly count distance
		/// </summary>
		/// <param name="control">control (button)</param>
		/// <returns>returns position of middle point</returns>
		private Point GetControlMidpoint()
		{
			return new Point()
			{
				X = button.Location.X + button.Width / 2,
				Y = button.Location.Y + button.Height / 2
			};
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

		private FormSides? IsOutOfRange()
		{
			Point pos = GetControlMidpoint();
			// if out of range
			if (pos.X > form.Width)
			{
				return FormSides.Right;
			}
			else if (pos.X < 0)
			{
				return FormSides.Left;
			}
			else if (pos.Y > form.Height)
			{
				return FormSides.Bottom;
			}
			else if (pos.Y < 0)
			{
				return FormSides.Top;
			}
			return null;
		}
	}
}


