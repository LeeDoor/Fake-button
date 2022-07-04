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
        private readonly double reacDist = 150d;

        public Form1()
        {
            InitializeComponent();
        }

        private double GetDistance (Point point, Control control)
        {
            Point point2 = GetControlMidpoint(control);
            Point distance = GetVector(point, point2);
            return Math.Sqrt(Math.Pow(distance.X,2) + Math.Pow(distance.Y, 2));
        }

        private Point GetControlMidpoint(Control control)
        {
            return new Point()
            {
                X = control.Location.X + control.Width / 2, 
                Y = control.Location.Y + control.Height / 2
            };
        }
        private Point GetVector(Point point, Point point2)
        {
            return new Point()
            {
                X = Math.Abs(point.X - point2.X), 
                Y = Math.Abs(point.Y - point2.Y)
            };
        }


        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            WrongButton.Text = GetDistance(InMousePosition, WrongButton).ToString();
            if (GetDistance(InMousePosition, WrongButton) < reacDist)
            {
                MoveOutwards(WrongButton);
            }
        }

        private void MoveOutwards(Control control)
        {
            Point backVector = GetVector(GetControlMidpoint(control), InMousePosition);
            InvertVector(backVector);
            ApplyMovement(control, backVector);
        }

        private Point InvertVector (Point point)
        {
            return new Point()
            {
                X = -point.X,
                Y = -point.Y
            };
        }

        private void ApplyMovement(Control control, Point vector)
        {
            control.Location = new Point()
            {
                X = control.Location.X + vector.X,
                Y = control.Location.Y + vector.Y
            };
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }


    }
}