using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Курсач
{
    public partial class okno : Form
    {
        private int[] clicks = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] damka  = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] rub =     new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[,] shah = new int[8, 8] { { 0, 21, 0, 22, 0, 23, 0, 24 }, { 17, 0, 18, 0, 19, 0, 20, 0 }, { 0, 13, 0, 14, 0, 15, 0, 16 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 9, 0, 10, 0, 11, 0, 12, 0 }, { 0, 5, 0, 6, 0, 7, 0, 8 }, { 1, 0, 2, 0, 3, 0, 4, 0 } };
        private int x0, y0,
            blackCount = 12,    // Count of black shashkas
            whiteCount = 12,    // Count of white shashkas
            direction = 0,      // Direction of turns
            turn = 0;           // Turns
        Point DownPoint;

        private void deleteShashka(int j, int i)
        {
            if (shah[i, j] == 1) shashka1.Visible = false;
            if (shah[i, j] == 2) shashka2.Visible = false;
            if (shah[i, j] == 3) shashka3.Visible = false;
            if (shah[i, j] == 4) shashka4.Visible = false;
            if (shah[i, j] == 5) shashka5.Visible = false;
            if (shah[i, j] == 6) shashka6.Visible = false;
            if (shah[i, j] == 7) shashka7.Visible = false;
            if (shah[i, j] == 8) shashka8.Visible = false;
            if (shah[i, j] == 9) shashka9.Visible = false;
            if (shah[i, j] == 10) shashka10.Visible = false;
            if (shah[i, j] == 11) shashka11.Visible = false;
            if (shah[i, j] == 12) shashka12.Visible = false;
            if (shah[i, j] == 13) shashka13.Visible = false;
            if (shah[i, j] == 14) shashka14.Visible = false;
            if (shah[i, j] == 15) shashka15.Visible = false;
            if (shah[i, j] == 16) shashka16.Visible = false;
            if (shah[i, j] == 17) shashka17.Visible = false;
            if (shah[i, j] == 18) shashka18.Visible = false;
            if (shah[i, j] == 19) shashka19.Visible = false;
            if (shah[i, j] == 20) shashka20.Visible = false;
            if (shah[i, j] == 21) shashka21.Visible = false;
            if (shah[i, j] == 22) shashka22.Visible = false;
            if (shah[i, j] == 23) shashka23.Visible = false;
            if (shah[i, j] == 24) shashka24.Visible = false;
        }

        private int rubl()
        {
            return 1;
        }

        private int allow(int x, int y)
        {
            rubl();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (shah[i, j] != 0) Console.Write(rub[shah[i, j] - 1]); else Console.Write(0);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------");

            int nx = (x - 17) / 58,
                ny = (y - 31) / 58,
                nX = (x0 - 17) / 58,
                nY = (y0 - 31) / 58,
                midx = (nx + nX) / 2,
                midy = (ny + nY) / 2;

            if ((nx < 0) || (nx > 7) || (ny < 0) || (ny > 7)) return 0;

            if (turn == 0) {
                if (direction == 0)
                {
                    if (shah[nY, nX] > 12) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if (((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY)) && (ny<nY))
                    {
                        if (shah[midy, midx] > 12)
                        {
                            deleteShashka(midx, midy);
                            shah[midy, midx] = 0;
                            blackCount--;
                            return 1;
                        }
                    }
                    if ((nY - ny != 1) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
                else
                {
                    if (shah[nY, nX] < 13) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if (((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY)) && (nY < ny))
                    {
                        if (shah[midy, midx] < 13)
                        {
                            deleteShashka(midx, midy);
                            shah[midy, midx] = 0;
                            blackCount--;
                            return 1;
                        }
                    }
                    if ((ny - nY != 1) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
            }
            else
            {
                if (direction == 0)
                {
                    if (shah[nY, nX] < 13) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if (((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY)) && (ny > nY))
                    {
                        if (shah[midy, midx] < 13)
                        {
                            deleteShashka(midx, midy);
                            shah[midy, midx] = 0;
                            whiteCount--;
                            return 1;
                        }
                    }
                    if ((ny - nY != 1) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
                else
                {
                    if (shah[nY, nX] > 12) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if (((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY)) && (nY > ny))
                    {
                        if (shah[midy, midx] > 12)
                        {
                            deleteShashka(midx, midy);
                            shah[midy, midx] = 0;
                            blackCount--;
                            return 1;
                        }
                    }
                    if ((nY - ny != 1) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
            }
            return 1;
             
        }

        private void gameover()
        {
            Form game = new gameover();
            if(whiteCount==0)
                game.BackgroundImage = Image.FromFile("bin\\images\\blackWin.png");
            if (blackCount == 0)
                game.BackgroundImage = Image.FromFile("bin\\images\\whiteWin.png");
            game.ShowDialog();
        }

        public okno()
        {
            InitializeComponent();
            setShahPosition();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            starts(shashka1, 1);
            starts(shashka2, 1);
            starts(shashka3, 1);
            starts(shashka4, 1);
            starts(shashka5, 1);
            starts(shashka6, 1);
            starts(shashka7, 1);
            starts(shashka8, 1);
            starts(shashka9, 1);
            starts(shashka10, 1);
            starts(shashka11, 1);
            starts(shashka12, 1);
            starts(shashka13, 0);
            starts(shashka14, 0);
            starts(shashka15, 0);
            starts(shashka16, 0);
            starts(shashka17, 0);
            starts(shashka18, 0);
            starts(shashka19, 0);
            starts(shashka20, 0);
            starts(shashka21, 0);
            starts(shashka22, 0);
            starts(shashka23, 0);
            starts(shashka24, 0);
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
            if (clicks[23] == 1)
            {
                Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y);
                shashka24.Location = new Point(shashka24.Location.X + dp.X, shashka24.Location.Y + dp.Y);
            }
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

        private void shashka12_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[11] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka12.Location = new Point(shashka12.Location.X + dp.X, shashka12.Location.Y + dp.Y); }

        }

        private void shashka11_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicks[10] == 1) { Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y); shashka11.Location = new Point(shashka11.Location.X + dp.X, shashka11.Location.Y + dp.Y); }

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


        //-----------------------------CLICKS------------------------------------
       
        //------------------------------END-CLICKS--------------------------------------------


        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("bin\\Readme.txt");
        }

        //1 - белый, иначе - черный
        private void starts(Button o, int cl)
        {
            o.BackColor = Color.Transparent;
            if (cl == 1) o.BackgroundImage = Image.FromFile("bin\\images\\whiteShashka.png"); else o.BackgroundImage = Image.FromFile("bin\\images\\blackShashka.png");
            o.FlatStyle = FlatStyle.Flat;
            o.FlatAppearance.BorderSize = 0;
            o.FlatAppearance.MouseDownBackColor = Color.Transparent;
            o.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void setShahPosition()
        {
            shashka1.Location = new Point(17, 437);


            shashka2.Location = new Point(133, 437);


            shashka3.Location = new Point(249, 437);


            shashka4.Location = new Point(365, 437);


            shashka5.Location = new Point(75, 379);


            shashka6.Location = new Point(191, 379);


            shashka7.Location = new Point(307, 379);


            shashka8.Location = new Point(423, 379);


            shashka9.Location = new Point(17, 321);


            shashka10.Location = new Point(133, 321);


            shashka11.Location = new Point(249, 321);


            shashka12.Location = new Point(365, 321);


            shashka13.Location = new Point(75, 147);


            shashka14.Location = new Point(191, 147);


            shashka15.Location = new Point(307, 147);


            shashka16.Location = new Point(423, 147);


            shashka17.Location = new Point(17, 89);


            shashka18.Location = new Point(133, 89);


            shashka19.Location = new Point(249, 89);


            shashka20.Location = new Point(365, 89);


            shashka21.Location = new Point(75, 31);


            shashka22.Location = new Point(191, 31);


            shashka23.Location = new Point(307, 31);


            shashka24.Location = new Point(423, 31);

            shashka1.Visible = true;
            shashka2.Visible = true;
            shashka3.Visible = true;
            shashka4.Visible = true;
            shashka5.Visible = true;
            shashka6.Visible = true;
            shashka7.Visible = true;
            shashka8.Visible = true;
            shashka9.Visible = true;
            shashka10.Visible = true;
            shashka11.Visible = true;
            shashka12.Visible = true;
            shashka13.Visible = true;
            shashka14.Visible = true;
            shashka15.Visible = true;
            shashka16.Visible = true;
            shashka17.Visible = true;
            shashka18.Visible = true;
            shashka19.Visible = true;
            shashka20.Visible = true;
            shashka21.Visible = true;
            shashka22.Visible = true;
            shashka23.Visible = true;
            shashka24.Visible = true;

            clicks = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            shah = new int[8, 8] { { 0, 21, 0, 22, 0, 23, 0, 24 }, { 17, 0, 18, 0, 19, 0, 20, 0 }, { 0, 13, 0, 14, 0, 15, 0, 16 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 9, 0, 10, 0, 11, 0, 12, 0 }, { 0, 5, 0, 6, 0, 7, 0, 8 }, { 1, 0, 2, 0, 3, 0, 4, 0 } };
            blackCount = 12;    // Count of black shashkas
            whiteCount = 12;    // Count of white shashkas
            direction = 0;      // Direction of turns
            turn = 0;
        }

        private void белыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setShahPosition();
            starts(shashka1, 1);
            starts(shashka2, 1);
            starts(shashka3, 1);
            starts(shashka4, 1);
            starts(shashka5, 1);
            starts(shashka6, 1);
            starts(shashka7, 1);
            starts(shashka8, 1);
            starts(shashka9, 1);
            starts(shashka10, 1);
            starts(shashka11, 1);
            starts(shashka12, 1);
            starts(shashka13, 0);
            starts(shashka14, 0);
            starts(shashka15, 0);
            starts(shashka16, 0);
            starts(shashka17, 0);
            starts(shashka18, 0);
            starts(shashka19, 0);
            starts(shashka20, 0);
            starts(shashka21, 0);
            starts(shashka22, 0);
            starts(shashka23, 0);
            starts(shashka24, 0);
            blackCount = 12;
            whiteCount = 12;
            direction = 0;
            turn = 0;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void черныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setShahPosition();
            starts(shashka1, 0);
            starts(shashka2, 0);
            starts(shashka3, 0);
            starts(shashka4, 0);
            starts(shashka5, 0);
            starts(shashka6, 0);
            starts(shashka7, 0);
            starts(shashka8, 0);
            starts(shashka9, 0);
            starts(shashka10, 0);
            starts(shashka11, 0);
            starts(shashka12, 0);
            starts(shashka13, 1);
            starts(shashka14, 1);
            starts(shashka15, 1);
            starts(shashka16, 1);
            starts(shashka17, 1);
            starts(shashka18, 1);
            starts(shashka19, 1);
            starts(shashka20, 1);
            starts(shashka21, 1);
            starts(shashka22, 1);
            starts(shashka23, 1);
            starts(shashka24, 1);
            blackCount = 12;
            whiteCount = 12;
            direction = 1;
            turn = 0;
        }
    }
}