namespace FakeButton
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// property gets position of mouse inside windows form
		/// </summary>
		public Point InMousePosition
		{
			get => new Point
			{
				X = MousePosition.X - Location.X - 5,
				Y = MousePosition.Y - Location.Y - 30
			};
		}

		/// <summary>
		/// button border property to get rectangle field
		/// </summary>
		public Rectangle ButtonBorder { get; private set; }

		/// <summary>
		/// button mover and communicator
		/// </summary>
		private ButtonMove buttonMove;

		/// <summary>
		/// constructor
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			buttonMove = new ButtonMove(WrongButton, this);
			ButtonBorder = new Rectangle(
				WrongButton.Width / 2,
				WrongButton.Height / 2,
				Width - WrongButton.Width - 5,
				Height - WrongButton.Height - 30
				);
		}

		/// <summary>
		/// event when mouse moves
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			buttonMove.MoveOutwards();
			RightButton.Enabled = false;
			queLabel.Enabled = false;
		}

		/// <summary>
		/// help gui drawing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnForm1Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(Color.White);
			e.Graphics.DrawEllipse(Pens.Red, new Rectangle(
				WrongButton.Location.X + WrongButton.Width/2 -  (int)buttonMove.reacDist,
				WrongButton.Location.Y + WrongButton.Height/2 - (int)buttonMove.reacDist,
				(int)buttonMove.reacDist* 2,
				(int)buttonMove.reacDist * 2
				)
			);

			e.Graphics.DrawRectangle(Pens.Green, ButtonBorder);
        }

		/// <summary>
		/// activates then mouse is on button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void OnWrongButtonMouseMove(object sender, MouseEventArgs e)
        {
			buttonMove.MoveOutwards();

		}
    }
}