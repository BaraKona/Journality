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
    public partial class floating1 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        private int totalSeconds;
        private int x = 0;
        public floating1()
        {
            //comment test
            InitializeComponent();
            button1.Text = "\u2713";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //combobox =  drop down box
        private void button2_Click(object sender, EventArgs e)
        {
            this.pauseButton.Enabled = false;
            this.StartButton.Enabled = true;
            this.comboBox1.Show();
            this.comboBox2.Show();

            timer1.Stop();
        }
        // Make window have shadows.
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

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer
            if(totalSeconds > 0)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds - (minutes * 60);

                this.label3.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                this.timer1.Stop();
                MessageBox.Show("Time is up! Take a break, stretch you legs");
            }
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void floating1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Journality.SetValueForText1;
            //disables button before timer start, so you cant click it until you have started
            this.pauseButton.Enabled = false;
            for(int i = 10; i<= 60; i++)
            {
                this.comboBox1.Items.Add(i.ToString());
                i = i +4;
            }
            for (int j = 0; j <60; ++j)
            {
                this.comboBox2.Items.Add(j.ToString());
                j = j + 14;
            }
            this.comboBox1.SelectedIndex = 10;
            this.comboBox2.SelectedIndex = 00;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (x == 0) { 
            this.comboBox1.Hide();
            this.comboBox2.Hide();
            this.label1.Hide();
            this.label2.Hide();
            //When pressed, button 4(this button) will be greyed out and unabe to be pressed again
            //button 2 the pause, will be enabled.
            this.StartButton.Enabled = false;
            this.pauseButton.Enabled = true;

            int minutes = int.Parse(this.comboBox1.SelectedItem.ToString());
            int seconds = int.Parse(this.comboBox2.SelectedItem.ToString());
                totalSeconds = (minutes * 60) + seconds;
                this.timer1.Enabled = true;
                int timertime = totalSeconds;
                ++x;
            }
            if (x >= 1)
            {
                this.comboBox1.Hide();
                this.comboBox2.Hide();
                this.label1.Hide();
                this.label2.Hide();
                this.StartButton.Enabled = false;
                this.pauseButton.Enabled = true;

                int minutes = int.Parse(this.comboBox1.SelectedItem.ToString());
                int seconds = int.Parse(this.comboBox2.SelectedItem.ToString());

                this.timer1.Enabled = true;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
