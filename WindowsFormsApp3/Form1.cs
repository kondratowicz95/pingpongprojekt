using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int points= 0;
        public Form1()
        {
            InitializeComponent();


            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racked.Top = background.Bottom - (background.Bottom / 10);

            label1.Left = (background.Width / 2) - (label1.Width / 2);
            label1.Top = (background.Height / 2) - (label1.Height / 2);
            label1.Visible = false;  // ukrywa strone label1 czyli gameover
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racked.Left = Cursor.Position.X - (racked.Width / 2);

            ball.Left += speed_left;
            ball.Top += speed_top;

            if (ball.Bottom >= racked.Top && ball.Bottom <= racked.Bottom && ball.Left >= racked.Left && ball.Right <= racked.Right) //odbicie piłki przez poprzeczkę
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top; // zmiana kierunku piłki 
                points += 1; // dodaje punkt
                points_lbl.Text = points.ToString();

             

            }

            if (ball.Left <= background.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right >= background.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= background.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= background.Bottom)
            {
                timer1.Enabled = false;
                label1.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }
            if(e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                background.Visible = false;

                 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
