namespace WF_DrawButton
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Point _startPoint = new Point();
        List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_startPoint.IsEmpty) return;
            _startPoint = e.Location;

            Button temp = new Button();
            temp.Location = _startPoint;

            temp.Width = 0;
            temp.Height = 0;
            temp.Text = buttons.Count.ToString();

            this.Controls.Add(temp);
            buttons.Add(temp);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_startPoint.IsEmpty) return;
            if (_startPoint.X > e.X) buttons[^1].Location = e.Location;
            else if (_startPoint.Y > e.Y) buttons[^1].Location = new Point(_startPoint.X, e.Y);

            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges

            buttons[^1].Width = Math.Abs(e.X - _startPoint.X);
            buttons[^1].Height = Math.Abs(e.Y - _startPoint.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _startPoint = Point.Empty;
            buttons[^1].BackColor = Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
        }
    }
}