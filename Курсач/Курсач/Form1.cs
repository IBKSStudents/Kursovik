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
            if (clicks[0] == 0) {
                int x, y;
                x = ((DownPoint.X - 17) / 58);
                x = (x * 58) + 17;
                y = ((DownPoint.Y -15) / 58);
                y = (x * 58) + 15;
                shashka1.Location = new Point(x, y);
                DownPoint = new Point();
            }
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

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void shashka2_Click(object sender, EventArgs e)
        {

        }

        private void shashka3_Click(object sender, EventArgs e)
        {
            clicks[2] = (clicks[2] + 1) % 2; if (clicks[2] == 0) { DownPoint = new Point(); }
            else
                shashka3.BringToFront();
    }

        private void shashka4_Click(object sender, EventArgs e)
        {
            clicks[3] = (clicks[3] + 1) % 2; if (clicks[3] == 0) { DownPoint = new Point(); }
            else
                shashka4.BringToFront();
        }

        private void shashka5_Click(object sender, EventArgs e)
        {
            clicks[4] = (clicks[4] + 1) % 2; if (clicks[4] == 0) { DownPoint = new Point(); }
            else
                shashka5.BringToFront();
        }

        private void shashka6_Click(object sender, EventArgs e)
        {
            clicks[5] = (clicks[5] + 1) % 2; if (clicks[5] == 0) { DownPoint = new Point(); }
            else
                shashka6.BringToFront();
        }

        private void shashka7_Click(object sender, EventArgs e)
        {
            clicks[6] = (clicks[6] + 1) % 2; if (clicks[6] == 0) { DownPoint = new Point(); }
            else
                shashka7.BringToFront();
        }

        private void shashka8_Click(object sender, EventArgs e)
        {
            clicks[7] = (clicks[7] + 1) % 2; if (clicks[7] == 0) { DownPoint = new Point(); }
            else
                shashka8.BringToFront();
        }

        private void shashka9_Click(object sender, EventArgs e)
        {
            clicks[8] = (clicks[8] + 1) % 2; if (clicks[8] == 0) { DownPoint = new Point(); }
            else
                shashka9.BringToFront();
        }

        private void shashka10_Click(object sender, EventArgs e)
        {
            clicks[9] = (clicks[9] + 1) % 2; if (clicks[9] == 0) { DownPoint = new Point(); }
            else
                shashka10.BringToFront();
        }

        private void shashka12_Click(object sender, EventArgs e)
        {
            clicks[11] = (clicks[11] + 1) % 2; if (clicks[11] == 0) { DownPoint = new Point(); }
            else
                shashka12.BringToFront();
        }

        private void shashka14_Click(object sender, EventArgs e)
        {
            clicks[13] = (clicks[13] + 1) % 2; if (clicks[13] == 0) { DownPoint = new Point(); }
            else
                shashka14.BringToFront();
        }

        private void shashka15_Click(object sender, EventArgs e)
        {
            clicks[14] = (clicks[14] + 1) % 2; if (clicks[14] == 0) { DownPoint = new Point(); }
            else
                shashka15.BringToFront();
        }

        private void shashka16_Click(object sender, EventArgs e)
        {
            clicks[15] = (clicks[15] + 1) % 2; if (clicks[15] == 0) { DownPoint = new Point(); }
            else
                shashka16.BringToFront();
        }

        private void shashka17_Click(object sender, EventArgs e)
        {
            clicks[16] = (clicks[16] + 1) % 2; if (clicks[16] == 0) { DownPoint = new Point(); }
            else
                shashka17.BringToFront();
        }

        private void shashka18_Click(object sender, EventArgs e)
        {
            clicks[17] = (clicks[17] + 1) % 2; if (clicks[17] == 0) { DownPoint = new Point(); }
            else
                shashka18.BringToFront();
        }

        private void shashka19_Click(object sender, EventArgs e)
        {
            clicks[18] = (clicks[18] + 1) % 2; if (clicks[18] == 0) { DownPoint = new Point(); }
            else
                shashka19.BringToFront();
        }

        private void shashka20_Click(object sender, EventArgs e)
        {
            clicks[19] = (clicks[19] + 1) % 2; if (clicks[19] == 0) { DownPoint = new Point(); }
            else
                shashka20.BringToFront();
        }

        private void shashka21_Click(object sender, EventArgs e)
        {
            clicks[20] = (clicks[20] + 1) % 2; if (clicks[20] == 0) { DownPoint = new Point(); }
            else
                shashka21.BringToFront();
        }

        private void shashka22_Click(object sender, EventArgs e)
        {
            clicks[21] = (clicks[21] + 1) % 2; if (clicks[21] == 0) { DownPoint = new Point(); }
            else
                shashka22.BringToFront();
        }

        private void shashka23_Click(object sender, EventArgs e)
        {
            clicks[22] = (clicks[22] + 1) % 2; if (clicks[22] == 0) { DownPoint = new Point(); }
            else
                shashka23.BringToFront();
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
            else
                shashka24.BringToFront();
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

        private void shashka18_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[17] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka18.Location = new Point(shashka18.Location.X + dp.X, shashka18.Location.Y + dp.Y); }

        }

        private void shashka17_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[16] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka17.Location = new Point(shashka17.Location.X + dp.X, shashka17.Location.Y + dp.Y); }

        }

        private void shashka16_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[15] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka16.Location = new Point(shashka16.Location.X + dp.X, shashka16.Location.Y + dp.Y); }

        }

        private void shashka15_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[14] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka15.Location = new Point(shashka15.Location.X + dp.X, shashka15.Location.Y + dp.Y); }

        }

        private void shashka14_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[13] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka14.Location = new Point(shashka14.Location.X + dp.X, shashka14.Location.Y + dp.Y); }

        }

        private void shashka13_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[12] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka13.Location = new Point(shashka13.Location.X + dp.X, shashka13.Location.Y + dp.Y); }

        }

        private void shashka13_Click(object sender, EventArgs e)
        {
            clicks[12] = (clicks[12] + 1) % 2; if (clicks[12] == 0) { DownPoint = new Point(); }
            else
                shashka13.BringToFront();
        }

        private void shashka12_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[11] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka12.Location = new Point(shashka12.Location.X + dp.X, shashka12.Location.Y + dp.Y); }

        }

        private void shashka11_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[10] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka11.Location = new Point(shashka11.Location.X + dp.X, shashka11.Location.Y + dp.Y); }

        }

        private void shashka11_Click(object sender, EventArgs e)
        {
            clicks[10] = (clicks[10] + 1) % 2; if (clicks[10] == 0) { DownPoint = new Point(); }
            else
                shashka11.BringToFront();
        }

        private void shashka10_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[9] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka10.Location = new Point(shashka10.Location.X + dp.X, shashka10.Location.Y + dp.Y); }

        }

        private void shashka9_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[8] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka9.Location = new Point(shashka9.Location.X + dp.X, shashka9.Location.Y + dp.Y); }

        }

        private void shashka8_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[7] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka8.Location = new Point(shashka8.Location.X + dp.X, shashka8.Location.Y + dp.Y); }

        }

        private void shashka7_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[6] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka7.Location = new Point(shashka7.Location.X + dp.X, shashka7.Location.Y + dp.Y); }

        }

        private void shashka6_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[5] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka6.Location = new Point(shashka6.Location.X + dp.X, shashka6.Location.Y + dp.Y); }

        }

        private void shashka5_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[4] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka5.Location = new Point(shashka5.Location.X + dp.X, shashka5.Location.Y + dp.Y); }

        }

        private void shashka4_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[3] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka4.Location = new Point(shashka4.Location.X + dp.X, shashka4.Location.Y + dp.Y); }

        }

        private void shashka3_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[2] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka3.Location = new Point(shashka3.Location.X + dp.X, shashka3.Location.Y + dp.Y); }

        }
    }
}
