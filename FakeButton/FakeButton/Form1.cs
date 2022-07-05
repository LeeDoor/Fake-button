namespace FakeButton
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// property gets position of mouse inside windows form
		/// </summary>
		public Point InMousePosition { get => new Point
		{
			X = MousePosition.X - Location.X - 5,
			Y = MousePosition.Y - Location.Y - 30
		};
		}

		/// <summary>
		/// variable gets info about button reaction distance
		/// </summary>
		private readonly double reacDist = 100d;

		/// <summary>
		/// ctor
		/// </summary>
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// event when mouse moves
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			WrongButton.Text = GetDistance(InMousePosition, WrongButton).ToString();
			if (GetDistance(InMousePosition, WrongButton) < reacDist)
			{
				MoveOutwards(WrongButton);
			}
		}

		/// <summary>
		/// func when button wants to move out of cursor
		/// </summary>
		/// <param name="control">button control</param>
		private void MoveOutwards(Control control)
		{
			Vector backVector = Vector.GetVector(GetControlMidpoint(control), InMousePosition).Invert();
			ApplyMovement(control, backVector);

			FormSides? side = IsOutOfRange(control);

			if (side != null)
			{
				var point = GetClosestBorderPoint(side.Value, control);
				ApplyMovement(control, Vector.GetVector(GetControlMidpoint(control), point));
			}
			this.Invalidate();
		}

		/// <summary>
		/// gets closest point which is enough far from cursor
		/// </summary>
		/// <param name="side">side, near you are</param>
		/// <param name="control">control button</param>
		/// <param name="space">recursivly getting space to count</param>
		/// <returns>returns far point</returns>
		private Point GetClosestBorderPoint(FormSides side, Control control, int space = 0)
		{
			if (space >= reacDist/2)
				return new Point()
				{
					X = Width / 2,
					Y = Height / 2
				};
			Point point = new();
			switch (side)
			{
				case FormSides.Left:
					point = new Point()
					{
						X = 0,
						Y = control.Location.Y + space
					};
					break;
				case FormSides.Right:
					point = new Point()
					{
						X = this.Width,
						Y = control.Location.Y + space
					};
					break;
				case FormSides.Bottom:
					point = new Point()
					{
						X = control.Location.X + space,
						Y = this.Height
					};
					break;
				case FormSides.Top:
					point = new Point()
					{
						X = control.Location.X + space,
						Y = 0
					};
					break;

			}
			if (GetDistance(InMousePosition, point) > reacDist)
			{
				return point;
			}
			else return GetClosestBorderPoint(side, control, -(space*+5));
		}

		/// <summary>
		/// gets distance between point and control
		/// </summary>
		/// <param name="point">point (mouse position)</param>
		/// <param name="control">control (button)</param>
		/// <returns>returns double distance</returns>
		private double GetDistance (Point point, Control control)
		{
			Point point2 = GetControlMidpoint(control);
			Vector distance = Vector.GetVector(point, point2).Module();
			return Math.Sqrt(Math.Pow(distance.X,2) + Math.Pow(distance.Y, 2));
		}

		/// <summary>
		/// gets distance between point and control
		/// </summary>
		/// <param name="point">point (mouse position)</param>
		/// <param name="point2">second point (screen borders)</param>
		/// <returns>returns double distance</returns>
		private double GetDistance(Point point, Point point2)
		{;
			Vector distance = Vector.GetVector(point, point2).Module();
			return Math.Sqrt(Math.Pow(distance.X, 2) + Math.Pow(distance.Y, 2));
		}

		/// <summary>
		/// gets middle point of control to correctly count distance
		/// </summary>
		/// <param name="control">control (button)</param>
		/// <returns>returns position of middle point</returns>
		private Point GetControlMidpoint(Control control)
		{
			return new Point()
			{
				X = control.Location.X + control.Width / 2, 
				Y = control.Location.Y + control.Height / 2
			};
		}

		/// <summary>
		/// applies vector to button coordinates
		/// </summary>
		/// <param name="control">control button</param>
		/// <param name="vector">vector</param>
		private void ApplyMovement(Control control, Vector vector)
		{
			control.Location = new Point()
			{
				X = control.Location.X + (int)vector.X,
				Y = control.Location.Y + (int)vector.Y
			};
		}

		private FormSides? IsOutOfRange(Control control)
		{
			Point pos = GetControlMidpoint(control);
			// if out of range
			if(pos.X > this.Width)
			{
				return FormSides.Right;
			}
			else if (pos.X < 0)
			{
				return FormSides.Left;
			}
			else if (pos.Y > this.Height)
			{
				return FormSides.Bottom;
			}
			else if (pos.Y < 0)
			{
				return FormSides.Top; 
			}
			return null;
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{

		}

		private void OnForm1Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(Color.White);
			e.Graphics.DrawEllipse(Pens.Red, new Rectangle(
				WrongButton.Location.X + WrongButton.Width/2 - (int)reacDist,
				WrongButton.Location.Y + WrongButton.Height/2 - (int)reacDist,
				(int)reacDist*2,
				(int)reacDist*2
				)
			);
        }
    }
}