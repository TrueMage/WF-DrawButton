namespace WF_DrawButton
{
    public partial class Form1 : Form
    {
        Point startPoint = new Point();
        List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!startPoint.IsEmpty) return;
            startPoint = e.Location;

            Button temp = new Button();
            temp.Location = startPoint;

            temp.Width = 0;
            temp.Height = 0;
            temp.Text = buttons.Count.ToString();

            this.Controls.Add(temp);
            buttons.Add(temp);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPoint.IsEmpty) return;

            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges
            buttons[^1].Width = e.X - startPoint.X;
            buttons[^1].Height = e.Y - startPoint.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            startPoint = Point.Empty;
        }
    }
}