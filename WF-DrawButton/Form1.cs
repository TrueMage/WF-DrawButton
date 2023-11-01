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
            startPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPoint.IsEmpty) return;

            Button temp = new Button();

            temp.Location = startPoint;
            temp.Width = startPoint.X - e.X;
            temp.Height = startPoint.Y - e.Y;
            temp.Text = buttons.Count.ToString();

            this.Controls.Add(temp);

            buttons.Add(temp);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}