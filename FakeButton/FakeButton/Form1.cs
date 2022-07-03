namespace FakeButton
{
    public partial class Form1 : Form
    {
        public Point InMousePosition { get => new Point 
        { 
            X = MousePosition.X - Location.X - 5, 
            Y = MousePosition.Y - Location.Y -30
        }; 
        }

        public Form1()
        {
            InitializeComponent();
        }

        private double GetDistance (Point point, Control control)
        {
            Point point2 = new Point() 
            { 
                X = control.Location.X + control.Width / 2, 
                Y = control.Location.Y + control.Height / 2 
            };
            Point distance = new Point() 
            {
                X = Math.Abs(point.X - point2.X), 
                Y = Math.Abs(point.Y - point2.Y) 
            };
            return Math.Sqrt(Math.Pow(distance.X,2) + Math.Pow(distance.Y, 2));
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            RightButton.Size = new Size() { Height = RightButton.Size.Height, Width = (int)GetDistance(InMousePosition, WrongButton) };
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}