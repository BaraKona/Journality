using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Journality : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        public Journality()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toppanel_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void toppanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void toppanel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
        //Make -  button minimise window
        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void toppanel_Paint(object sender, PaintEventArgs e)
        {

        }
        // Make window have shaddows
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        private void tasks1_Click(object sender, EventArgs e)
        {
          
        }
        private void tasks1_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Modern No. 20", 9);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.WhiteSmoke);
            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Tasks", myfont, mybrush, 0, 0);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
