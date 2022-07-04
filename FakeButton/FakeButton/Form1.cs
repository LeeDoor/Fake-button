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
            Vector distance = GetVector(point, point2).Module();
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
        private Vector GetVector(Point point, Point point2)
        {
            return new Vector()
            {
                X = point.X - point2.X, 
                Y = point.Y - point2.Y
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
            Vector backVector = GetVector(GetControlMidpoint(control), InMousePosition); //;/.Invert();
            ApplyMovement(control, backVector);
        }

        private void ApplyMovement(Control control, Vector vector)
        {
            control.Location = new Point()
            {
                X = control.Location.X + (int)vector.X,
                Y = control.Location.Y + (int)vector.Y
            };
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }


    }
}