using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Курсач
{ 
    public partial class okno : Form
    {
       private int[] clicks = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Point DownPoint;

        public okno()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void shashka1_Click(object sender, EventArgs e)
        {
           clicks[0] = (clicks[0] + 1) % 2;
            if (clicks[0] == 0) { DownPoint = new Point(); }
            else
                shashka1.BringToFront();
        }

        private void shashka1_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[0] == 1)
            {
                Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y);
                shashka1.Location = new Point(shashka1.Location.X + dp.X, shashka1.Location.Y + dp.Y);
            }
        }

        private void shashka2_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka2_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[1] == 1)
            {
                Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y);
                shashka2.Location = new Point(shashka2.Location.X + dp.X, shashka2.Location.Y + dp.Y);
            }
        }

        private void shashka2_MouseClick(object sender, MouseEventArgs e)
        {
            clicks[1] = (clicks[1] + 1) % 2;
            if (clicks[1] == 0) { DownPoint = new Point(); }
            else
                shashka2.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void shashka2_Click(object sender, EventArgs e)
        {

        }

        private void shashka3_Click(object sender, EventArgs e)
        {

        }

        private void shashka4_Click(object sender, EventArgs e)
        {

        }

        private void shashka5_Click(object sender, EventArgs e)
        {

        }

        private void shashka6_Click(object sender, EventArgs e)
        {

        }

        private void shashka7_Click(object sender, EventArgs e)
        {

        }

        private void shashka8_Click(object sender, EventArgs e)
        {

        }

        private void shashka9_Click(object sender, EventArgs e)
        {

        }

        private void shashka10_Click(object sender, EventArgs e)
        {

        }

        private void shashka12_Click(object sender, EventArgs e)
        {

        }

        private void shashka14_Click(object sender, EventArgs e)
        {

        }

        private void shashka15_Click(object sender, EventArgs e)
        {

        }

        private void shashka16_Click(object sender, EventArgs e)
        {

        }

        private void shashka17_Click(object sender, EventArgs e)
        {

        }

        private void shashka18_Click(object sender, EventArgs e)
        {

        }

        private void shashka19_Click(object sender, EventArgs e)
        {
            clicks[18] = (clicks[18] + 1) % 2; if (clicks[18] == 0) { DownPoint = new Point(); }

        }

        private void shashka20_Click(object sender, EventArgs e)
        {
            clicks[19] = (clicks[19] + 1) % 2; if (clicks[19] == 0) { DownPoint = new Point(); }
        }

        private void shashka21_Click(object sender, EventArgs e)
        {
            clicks[20] = (clicks[20] + 1) % 2; if (clicks[20] == 0) { DownPoint = new Point(); }
        }

        private void shashka22_Click(object sender, EventArgs e)
        {
            clicks[21] = (clicks[21] + 1) % 2; if (clicks[21] == 0) { DownPoint = new Point(); }
        }

        private void shashka23_Click(object sender, EventArgs e)
        {
            clicks[22] = (clicks[22] + 1) % 2; if (clicks[22] == 0) { DownPoint = new Point(); }
        }

        private void shashka3_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void shashka3_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka4_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka5_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka6_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka7_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka8_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka9_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka10_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka11_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka12_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka13_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka14_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka15_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka16_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka17_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka18_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka19_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka20_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka21_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka22_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka23_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka24_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }

        private void shashka24_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[23] == 1) {
                Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y);
                shashka24.Location = new Point(shashka24.Location.X + dp.X, shashka24.Location.Y + dp.Y);
            }
        }

        private void shashka24_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void shashka24_Click(object sender, EventArgs e)
        {
            clicks[23] = (clicks[23] + 1) % 2; if (clicks[23] == 0) { DownPoint = new Point(); }
        }

        private void shashka23_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[22] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka23.Location = new Point(shashka23.Location.X + dp.X, shashka23.Location.Y + dp.Y); }
        }

        private void shashka22_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[21] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka22.Location = new Point(shashka22.Location.X + dp.X, shashka22.Location.Y + dp.Y); }
        }

        private void shashka21_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[20] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka21.Location = new Point(shashka21.Location.X + dp.X, shashka21.Location.Y + dp.Y); }
        }

        private void shashka20_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[19] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka20.Location = new Point(shashka20.Location.X + dp.X, shashka20.Location.Y + dp.Y); }
        }

        private void shashka19_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[18] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka19.Location = new Point(shashka19.Location.X + dp.X, shashka19.Location.Y + dp.Y); }

        }
    }
}
