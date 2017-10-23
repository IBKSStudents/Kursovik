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
using System.Threading;
using System.Net;
using System.Net.Sockets;


namespace Курсач
{
    public partial class okno : Form
    {
        private int[]    clicks   =      new int[]         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private Button[] shahOb   =      new Button[24];
        private Point[]  loc      =      new Point[24];
        private bool[]   vis      =      new bool[24];
        private int[]    damka    =      new int[]         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[]    damkas   =      new int[]         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[]    rub      =      new int[]         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[]    rubs     =      new int[]         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[,]   shah     =      new int[8, 8]   { { 0, 21, 0, 22, 0, 23, 0, 24 }, { 17, 0, 18, 0, 19, 0, 20, 0 }, { 0, 13, 0, 14, 0, 15, 0, 16 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 9, 0, 10, 0, 11, 0, 12, 0 }, { 0, 5, 0, 6, 0, 7, 0, 8 }, { 1, 0, 2, 0, 3, 0, 4, 0 } };
        private int[,]   shahs    =      new int[8, 8]   { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };
        private int[,]   shashki  =      new int[12, 9]  { { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        private int[,]   hodi     =      new int[8, 2]   { { -2, 2 }, { -2, -2 }, { -1, 1 }, { -1, -1 }, { 1, -1 }, { 1, 1 }, { 2, -2 }, { 2, 2 } };
        private int x0, y0, rubly = 0,
            rublys = 0,         // rubly for hod compa
            blackCount = 12,    // Count of black shashkas
            whiteCount = 12,    // Count of white shashkas
            blackCounts = 12,   // Count of black shashkas
            whiteCounts = 12,   // Count of white shashkas
            direction = 0,      // Direction of turns
            turn = 0,           // Turns
            turns = 0,          // Turns
            computer = 0,       // Game with computer or no
            GameIsOver = 0,     // When gameover
            DamkaNoComp = 0,    // To dispose error with damka and hod compa
            DamkaNoComps = 0,    // To dispose error with damka and hod compa
            priora = 0,         // Max prioritet hoda compa
            frubl,              // Begining rubly
            index = 0;          // Count of shashkas allowed to move
        private Point DownPoint, center;
        private Random rnd = new Random();

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

        private void setDamka(int i, int j)
        {
            DamkaNoComp = 1;

            if (shah[i, j] == 1)
            {
                damka[0] = 1;
                if (turn == 0) shashka1.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka1.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 2)
            {
                damka[1] = 1;
                if (turn == 0) shashka2.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka2.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 3)
            {
                damka[2] = 1;
                if (turn == 0) shashka3.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka3.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 4)
            {
                damka[3] = 1;
                if (turn == 0) shashka4.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka4.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 5)
            {
                damka[4] = 1;
                if (turn == 0) shashka5.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka5.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 6)
            {
                damka[5] = 1;
                if (turn == 0) shashka6.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka6.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 7)
            {
                damka[6] = 1;
                if (turn == 0) shashka7.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka7.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 8)
            {
                damka[7] = 1;
                if (turn == 0) shashka8.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka8.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 9)
            {
                damka[8] = 1;
                if (turn == 0) shashka9.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka9.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 10)
            {
                damka[9] = 1;
                if (turn == 0) shashka10.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka10.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 11)
            {
                damka[10] = 1;
                if (turn == 0) shashka11.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka11.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 12)
            {
                damka[11] = 1;
                if (turn == 0) shashka12.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka12.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 13)
            {
                damka[12] = 1;
                if (turn == 0) shashka13.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka13.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 14)
            {
                damka[13] = 1;
                if (turn == 0) shashka14.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka14.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 15)
            {
                damka[14] = 1;
                if (turn == 0) shashka15.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka15.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 16)
            {
                damka[15] = 1;
                if (turn == 0) shashka16.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka16.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 17)
            {
                damka[16] = 1;
                if (turn == 0) shashka17.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka17.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 18)
            {
                damka[17] = 1;
                if (turn == 0) shashka18.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka18.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 19)
            {
                damka[18] = 1;
                if (turn == 0) shashka19.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka19.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 20)
            {
                damka[19] = 1;
                if (turn == 0) shashka20.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka20.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 21)
            {
                damka[20] = 1;
                if (turn == 0) shashka21.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka21.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 22)
            {
                damka[21] = 1;
                if (turn == 0) shashka22.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka22.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 23)
            {
                damka[22] = 1;
                if (turn == 0) shashka23.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka23.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            if (shah[i, j] == 24)
            {
                damka[23] = 1;
                if (turn == 0) shashka24.BackgroundImage = Image.FromFile("bin\\images\\whiteDamka.png"); else shashka24.BackgroundImage = Image.FromFile("bin\\images\\blackDamka.png");
            }
            turn = (turn + 1) % 2;
        }

        private void checkDamka(int j, int i)
        {
            if (turn == 0)
            {
                if (direction == 0)
                {
                    if ((j == 0) && (damka[shah[j, i] - 1] == 0)) setDamka(j, i);
                    return;
                }
                else
                {
                    if ((j == 7) && (damka[shah[j, i] - 1] == 0)) setDamka(j, i);
                    return;
                }
            }
            else
            {
                if (direction == 0)
                {
                    if ((j == 7) && (damka[shah[j, i] - 1] == 0)) setDamka(j, i);                   
                    return;
                }
                else
                {
                    if ((j == 0) && (damka[shah[j, i] - 1] == 0)) setDamka(j, i);
                    return;
                }
            }
        }

        private void checkDamkas(int j, int i)
        {
            if (turns == 0)
            {
                if (direction == 0)
                {
                    if ((j == 0) && (damkas[shahs[j, i] - 1] == 0))
                    {
                        damkas[shahs[j, i] - 1] = 1;
                        DamkaNoComps = 1;
                        turns = (turns + 1) % 2;
                    }
                    return;
                }
                else
                {
                    if ((j == 7) && (damkas[shahs[j, i] - 1] == 0))
                    {
                        damkas[shahs[j, i] - 1] = 1;
                        DamkaNoComps = 1;
                        turns = (turns + 1) % 2;
                    }
                    return;
                }
            }
            else
            {
                if (direction == 0)
                {
                    if ((j == 7) && (damkas[shahs[j, i] - 1] == 0))
                    {
                        damkas[shahs[j, i] - 1] = 1;
                        DamkaNoComps = 1;
                        turns = (turns + 1) % 2;
                    }
                    return;
                }
                else
                {
                    if ((j == 0) && (damkas[shahs[j, i] - 1] == 0))
                    {
                        damkas[shahs[j, i] - 1] = 1;
                        DamkaNoComps = 1;
                        turns = (turns + 1) % 2;
                    }
                    return;
                }
            }
        }

        private int rubl()
        {
            int r = 0, x, y, x00, y00, x1l, x2l, y1l, y2l, x1r, x2r, y1r, y2r, d1r, d1l, d2r, d2l;
            for (int i = 0; i < 24; i++) rub[i] = 0;

            if (turn == 0)
            {
                if (direction == 0)
                {
                    // White 1-12
                    for (int numb = 0; numb < 12; numb++)
                    {
                        if (shahOb[numb].Visible == true)
                        {
                            x = shahOb[numb].Location.X;
                            y = shahOb[numb].Location.Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 - 1;
                            x1r = x00 + 1;
                            y1r = y00 - 1;
                            x2l = x00 - 2;
                            y2l = y00 - 2;
                            x2r = x00 + 2;
                            y2r = y00 - 2;
                            if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                            {
                                if (((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0)))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r >= 0))
                            {
                                if ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l >= 0))
                            {
                                if ((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }

                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 + 1;
                                x1r = x00 + 1;
                                y1r = y00 + 1;
                                x2l = x00 - 2;
                                y2l = y00 + 2;
                                x2r = x00 + 2;
                                y2r = y00 + 2;
                                if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                                {
                                    if (((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0)))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r <= 7))
                                {
                                    if ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l <= 7))
                                {
                                    if ((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                    }
                }
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                else
                {
                    // White 13-24
                    for (int numb = 12; numb < 24; numb++)
                    {
                        if (shahOb[numb].Visible == true)
                        {
                            x = shahOb[numb].Location.X;
                            y = shahOb[numb].Location.Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 + 1;
                            x1r = x00 + 1;
                            y1r = y00 + 1;
                            x2l = x00 - 2;
                            y2l = y00 + 2;
                            x2r = x00 + 2;
                            y2r = y00 + 2;
                            if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                            {
                                if (((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0)))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r <= 7))
                            {
                                if ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l <= 7))
                            {
                                if ((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            
                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 - 1;
                                x1r = x00 + 1;
                                y1r = y00 - 1;
                                x2l = x00 - 2;
                                y2l = y00 - 2;
                                x2r = x00 + 2;
                                y2r = y00 - 2;
                                if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                                {
                                    if (((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0)))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r >= 0))
                                {
                                    if ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l >= 0))
                                {
                                    if ((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                    }
                }       
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================

            }
            else
            {
                if (direction == 0)
                {
                    // Black 13-24
                    for (int numb = 12; numb < 24; numb++)
                    {
                        if (shahOb[numb].Visible == true)
                        {
                            x = shahOb[numb].Location.X;
                            y = shahOb[numb].Location.Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 + 1;
                            x1r = x00 + 1;
                            y1r = y00 + 1;
                            x2l = x00 - 2;
                            y2l = y00 + 2;
                            x2r = x00 + 2;
                            y2r = y00 + 2;
                            if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                            {
                                if (((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0)))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r <= 7))
                            {
                                if ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l <= 7))
                            {
                                if ((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }

                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 - 1;
                                x1r = x00 + 1;
                                y1r = y00 - 1;
                                x2l = x00 - 2;
                                y2l = y00 - 2;
                                x2r = x00 + 2;
                                y2r = y00 - 2;
                                if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                                {
                                    if (((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0)))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r >= 0))
                                {
                                    if ((shah[y1r, x1r] < 13) && (shah[y1r, x1r] > 0) && (shah[y2r, x2r] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l >= 0))
                                {
                                    if ((shah[y1l, x1l] < 13) && (shah[y1l, x1l] > 0) && (shah[y2l, x2l] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                    }
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                }
                else
                {
                    // Black 1-12
                    for (int numb = 0; numb < 12; numb++)
                    {
                        if (shahOb[numb].Visible == true)
                        {
                            x = shahOb[numb].Location.X;
                            y = shahOb[numb].Location.Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 - 1;
                            x1r = x00 + 1;
                            y1r = y00 - 1;
                            x2l = x00 - 2;
                            y2l = y00 - 2;
                            x2r = x00 + 2;
                            y2r = y00 - 2;
                            if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                            {
                                if (((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0)))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r >= 0))
                            {
                                if ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l >= 0))
                            {
                                if ((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0))
                                {
                                    rub[numb] = 1;
                                    r = 1;
                                }
                            }

                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 + 1;
                                x1r = x00 + 1;
                                y1r = y00 + 1;
                                x2l = x00 - 2;
                                y2l = y00 + 2;
                                x2r = x00 + 2;
                                y2r = y00 + 2;
                                if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                                {
                                    if (((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0)) || ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0)))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r <= 7))
                                {
                                    if ((shah[y1r, x1r] < 25) && (shah[y1r, x1r] > 12) && (shah[y2r, x2r] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l <= 7))
                                {
                                    if ((shah[y1l, x1l] < 25) && (shah[y1l, x1l] > 12) && (shah[y2l, x2l] == 0))
                                    {
                                        rub[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                    }
                }
            }
            return r;
        }

        private int rubls()
        {
            int r = 0, x, y, x00, y00, x1l, x2l, y1l, y2l, x1r, x2r, y1r, y2r, d1r, d1l, d2r, d2l;
            for (int i = 0; i < 24; i++) rubs[i] = 0;

            if (turn == 0)
            {
                if (direction == 0)
                {
                    // White 1-12
                    for (int numb = 0; numb < 12; numb++)
                    {
                        if (vis[numb] == true)
                        {
                            x = loc[numb].X;
                            y = loc[numb].Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 - 1;
                            x1r = x00 + 1;
                            y1r = y00 - 1;
                            x2l = x00 - 2;
                            y2l = y00 - 2;
                            x2r = x00 + 2;
                            y2r = y00 - 2;
                            if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                            {
                                if (((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0)))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r >= 0))
                            {
                                if ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l >= 0))
                            {
                                if ((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }

                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 + 1;
                                x1r = x00 + 1;
                                y1r = y00 + 1;
                                x2l = x00 - 2;
                                y2l = y00 + 2;
                                x2r = x00 + 2;
                                y2r = y00 + 2;
                                if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                                {
                                    if (((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0)))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r <= 7))
                                {
                                    if ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l <= 7))
                                {
                                    if ((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                    }
                }
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                else
                {
                    // White 13-24
                    for (int numb = 12; numb < 24; numb++)
                    {
                        if (vis[numb] == true)
                        {
                            x = loc[numb].X;
                            y = loc[numb].Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 + 1;
                            x1r = x00 + 1;
                            y1r = y00 + 1;
                            x2l = x00 - 2;
                            y2l = y00 + 2;
                            x2r = x00 + 2;
                            y2r = y00 + 2;
                            if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                            {
                                if (((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0)))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r <= 7))
                            {
                                if ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l <= 7))
                            {
                                if ((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }

                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 - 1;
                                x1r = x00 + 1;
                                y1r = y00 - 1;
                                x2l = x00 - 2;
                                y2l = y00 - 2;
                                x2r = x00 + 2;
                                y2r = y00 - 2;
                                if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                                {
                                    if (((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0)))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r >= 0))
                                {
                                    if ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l >= 0))
                                {
                                    if ((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                    }
                }
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================
                //===================================================================================================================

            }
            else
            {
                if (direction == 0)
                {
                    // Black 13-24
                    for (int numb = 12; numb < 24; numb++)
                    {
                        if (vis[numb] == true)
                        {
                            x = loc[numb].X;
                            y = loc[numb].Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 + 1;
                            x1r = x00 + 1;
                            y1r = y00 + 1;
                            x2l = x00 - 2;
                            y2l = y00 + 2;
                            x2r = x00 + 2;
                            y2r = y00 + 2;
                            if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                            {
                                if (((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0)))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r <= 7))
                            {
                                if ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l <= 7))
                            {
                                if ((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }

                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 - 1;
                                x1r = x00 + 1;
                                y1r = y00 - 1;
                                x2l = x00 - 2;
                                y2l = y00 - 2;
                                x2r = x00 + 2;
                                y2r = y00 - 2;
                                if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                                {
                                    if (((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0)))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r >= 0))
                                {
                                    if ((shahs[y1r, x1r] < 13) && (shahs[y1r, x1r] > 0) && (shahs[y2r, x2r] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l >= 0))
                                {
                                    if ((shahs[y1l, x1l] < 13) && (shahs[y1l, x1l] > 0) && (shahs[y2l, x2l] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                    }
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                    //======================================================================================
                }
                else
                {
                    // Black 1-12
                    for (int numb = 0; numb < 12; numb++)
                    {
                        if (vis[numb] == true)
                        {
                            x = loc[numb].X;
                            y = loc[numb].Y;
                            x00 = (x - 17) / 58;
                            y00 = (y - 31) / 58;
                            x1l = x00 - 1;
                            y1l = y00 - 1;
                            x1r = x00 + 1;
                            y1r = y00 - 1;
                            x2l = x00 - 2;
                            y2l = y00 - 2;
                            x2r = x00 + 2;
                            y2r = y00 - 2;
                            if ((x2l >= 0) && (y2l >= 0) && (x2r <= 7))
                            {
                                if (((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0)))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2l < 0) && (y2r >= 0))
                            {
                                if ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }
                            if ((x2r > 7) && (y2l >= 0))
                            {
                                if ((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0))
                                {
                                    rubs[numb] = 1;
                                    r = 1;
                                }
                            }

                            if (damka[numb] == 1)
                            {
                                x1l = x00 - 1;
                                y1l = y00 + 1;
                                x1r = x00 + 1;
                                y1r = y00 + 1;
                                x2l = x00 - 2;
                                y2l = y00 + 2;
                                x2r = x00 + 2;
                                y2r = y00 + 2;
                                if ((x2l >= 0) && (y2l <= 7) && (x2r <= 7))
                                {
                                    if (((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0)) || ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0)))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2l < 0) && (y2r <= 7))
                                {
                                    if ((shahs[y1r, x1r] < 25) && (shahs[y1r, x1r] > 12) && (shahs[y2r, x2r] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                                if ((x2r > 7) && (y2l <= 7))
                                {
                                    if ((shahs[y1l, x1l] < 25) && (shahs[y1l, x1l] > 12) && (shahs[y2l, x2l] == 0))
                                    {
                                        rubs[numb] = 1;
                                        r = 1;
                                    }
                                }
                            }
                        }
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                        //=====================================================================================
                    }
                }
            }
            return r;
        }

        private int allow(int x, int y)
        {

            int nx = (x - 17) / 58,
                ny = (y - 31) / 58,
                nX = (x0 - 17) / 58,
                nY = (y0 - 31) / 58,
                midx = (nx + nX) / 2,
                midy = (ny + nY) / 2;


            if ((nx < 0) || (nx > 7) || (ny < 0) || (ny > 7)) return 0;

            if (turn == 0)
            {
                if (direction == 0)
                {
                    if (rubly == 1)
                    {
                        if (rub[shah[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shah[nY, nX] > 12) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damka[shah[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damka[shah[nY, nX] - 1] == 0) && (ny > nY)) return 0;
                        if (shah[midy, midx] > 12)
                        {
                            if (shah[midy, midx] == 0) return 0;
                            deleteShashka(midx, midy);
                            damka[shah[midy, midx] - 1] = 0;
                            shah[midy, midx] = 0;
                            blackCount--;
                            return 1;
                        }
                    }
                    if (((nY - ny != 1) && (damka[shah[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
                else
                {
                    if (rubly == 1)
                    {
                        if (rub[shah[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shah[nY, nX] < 13) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damka[shah[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damka[shah[nY, nX] - 1] == 0) && (ny < nY)) return 0;
                        if (shah[midy, midx] < 13)
                        {
                            if (shah[midy, midx] == 0) return 0;
                            deleteShashka(midx, midy);
                            damka[shah[midy, midx] - 1] = 0;
                            shah[midy, midx] = 0;
                            blackCount--;
                            return 1;
                        }
                    }
                    if (((ny - nY != 1) && (damka[shah[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
            }
            else
            {
                if (direction == 0)
                {
                    if (rubly == 1)
                    {
                        if (rub[shah[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shah[nY, nX] < 13) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damka[shah[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damka[shah[nY, nX] - 1] == 0) && (ny < nY)) return 0;
                        if (shah[midy, midx] < 13)
                        {
                            if (shah[midy, midx] == 0) return 0;
                            deleteShashka(midx, midy);
                            damka[shah[midy, midx] - 1] = 0;
                            shah[midy, midx] = 0;
                            whiteCount--;
                            return 1;
                        }
                    }
                    if (((ny - nY != 1) && (damka[shah[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
                else
                {
                    if (rubly == 1)
                    {
                        if (rub[shah[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shah[nY, nX] > 12) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shah[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damka[shah[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damka[shah[nY, nX] - 1] == 0) && (ny > nY)) return 0;
                        if (shah[midy, midx] > 12)
                        {
                            if (shah[midy, midx] == 0) return 0;
                            deleteShashka(midx, midy);
                            damka[shah[midy, midx] - 1] = 0;
                            shah[midy, midx] = 0;
                            whiteCount--;
                            return 1;
                        }
                    }
                    if (((nY - ny != 1) && (damka[shah[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
            }
            return 1;

        }

        private int allows(int X0, int Y0, int x, int y)
        {

            int nx = (x - 17) / 58,
                ny = (y - 31) / 58,
                nX = (X0 - 17) / 58,
                nY = (Y0 - 31) / 58,
                midx = (nx + nX) / 2,
                midy = (ny + nY) / 2;


            if ((nx < 0) || (nx > 7) || (ny < 0) || (ny > 7)) return 0;

            if (turns == 0)
            {
                if (direction == 0)
                {
                    if (rublys == 1)
                    {
                        if (rubs[shahs[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shahs[nY, nX] > 12) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shahs[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damkas[shahs[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damkas[shahs[nY, nX] - 1] == 0) && (ny > nY)) return 0;
                        if (shahs[midy, midx] > 12)
                        {
                            if (shahs[midy, midx] == 0) return 0;
                            damkas[shahs[midy, midx] - 1] = 0;
                            shahs[midy, midx] = 0;
                            whiteCounts--;
                            return 4;
                        }
                    }
                    if (((nY - ny != 1) && (damkas[shahs[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
                else
                {
                    if (rublys == 1)
                    {
                        if (rubs[shahs[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shahs[nY, nX] < 13) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shahs[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damkas[shahs[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damkas[shahs[nY, nX] - 1] == 0) && (ny < nY)) return 0;
                        if (shahs[midy, midx] < 13)
                        {
                            if (shahs[midy, midx] == 0) return 0;
                            damkas[shahs[midy, midx] - 1] = 0;
                            shahs[midy, midx] = 0;
                            whiteCounts--;
                            return 4;
                        }
                    }
                    if (((ny - nY != 1) && (damkas[shahs[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
            }
            else
            {
                if (direction == 0)
                {
                    if (rublys == 1)
                    {
                        if (rubs[shahs[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shahs[nY, nX] < 13) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shahs[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damkas[shahs[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damkas[shahs[nY, nX] - 1] == 0) && (ny < nY)) return 0;
                        if (shahs[midy, midx] < 13)
                        {
                            if (shahs[midy, midx] == 0) return 0;
                            damkas[shahs[midy, midx] - 1] = 0;
                            shahs[midy, midx] = 0;
                            blackCounts--;
                            return 4;
                        }
                    }
                    if (((ny - nY != 1) && (damkas[shahs[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
                else
                {
                    if (rublys == 1)
                    {
                        if (rubs[shahs[nY, nX] - 1] == 0) return 0;
                        else
                        {
                            if ((midx == nx) || (midx == nX) || (midy == ny) || (midy == nY)) return 0;
                        }
                    }
                    if (shahs[nY, nX] > 12) return 0;
                    if ((nx == nX) || (ny == nY)) return 0;
                    if (shahs[ny, nx] != 0) return 0;
                    if ((midx != nx) && (midx != nX) && (midy != ny) && (midy != nY))
                    {
                        if ((damkas[shahs[nY, nX] - 1] == 1) && (((nY - ny) > 2) || (((nY - ny) < -2)))) return 0;
                        if ((damkas[shahs[nY, nX] - 1] == 0) && (ny > nY)) return 0;
                        if (shahs[midy, midx] > 12)
                        {
                            if (shahs[midy, midx] == 0) return 0;
                            damkas[shahs[midy, midx] - 1] = 0;
                            shahs[midy, midx] = 0;
                            blackCounts--;
                            return 4;
                        }
                    }
                    if (((nY - ny != 1) && (damkas[shahs[nY, nX] - 1] == 0)) || (nX - nx > 1) || (nx - nX > 1)) return 0;
                }
            }
            return 1;

        }

        private void setCoord()
        {
            vis[0] = shashka1.Visible;
            loc[0] = shashka1.Location;
            vis[1] = shashka2.Visible;
            loc[1] = shashka2.Location;
            vis[2] = shashka3.Visible;
            loc[2] = shashka3.Location;
            vis[3] = shashka4.Visible;
            loc[3] = shashka4.Location;
            vis[4] = shashka5.Visible;
            loc[4] = shashka5.Location;
            vis[5] = shashka6.Visible;
            loc[5] = shashka6.Location;
            vis[6] = shashka7.Visible;
            loc[6] = shashka7.Location;
            vis[7] = shashka8.Visible;
            loc[7] = shashka8.Location;
            vis[8] = shashka9.Visible;
            loc[8] = shashka9.Location;
            vis[9] = shashka10.Visible;
            loc[9] = shashka10.Location;
            vis[10] = shashka11.Visible;
            loc[10] = shashka11.Location;
            vis[11] = shashka12.Visible;
            loc[11] = shashka12.Location;
            vis[12] = shashka13.Visible;
            loc[12] = shashka13.Location;
            vis[13] = shashka14.Visible;
            loc[13] = shashka14.Location;
            vis[14] = shashka15.Visible;
            loc[14] = shashka15.Location;
            vis[15] = shashka16.Visible;
            loc[15] = shashka16.Location;
            vis[16] = shashka17.Visible;
            loc[16] = shashka17.Location;
            vis[17] = shashka18.Visible;
            loc[17] = shashka18.Location;
            vis[18] = shashka19.Visible;
            loc[18] = shashka19.Location;
            vis[19] = shashka20.Visible;
            loc[19] = shashka20.Location;
            vis[20] = shashka21.Visible;
            loc[20] = shashka21.Location;
            vis[21] = shashka22.Visible;
            loc[21] = shashka22.Location;
            vis[22] = shashka23.Visible;
            loc[22] = shashka23.Location;
            vis[23] = shashka24.Visible;
            loc[23] = shashka24.Location;
            shahs = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };
            for(int i = 0; i < 24; i++)
            {
                if(vis[i]==true) shahs[(loc[i].Y - 31) / 58, (loc[i].X - 17) / 58] = i + 1;
                damkas[i] = damka[i];
                rubs[i] = rub[i];
            }
            turns = turn;
            blackCounts = blackCount;
            whiteCounts = whiteCount;
            rublys = rubly;
            frubl = rubly;
            DamkaNoComps = 0;
        }

        private void cAllow(Button s)
        {
            int X0 = s.Location.X,
                Y0 = s.Location.Y,
                x, y;

            int fdamka;
            for (int j = 0; j < 8; j++)
            {
                setCoord();
                fdamka = damkas[shahs[(Y0 - 31) / 58, (X0 - 17) / 58] - 1];
                x = X0 + 58 * hodi[j, 0];
                y = Y0 + 58 * hodi[j, 1];
                shashki[index, j + 1] = 0;
                int al = allows(X0, Y0, x, y);
                if (al > 0)
                {
                    shahs[(y - 31) / 58, (x - 17) / 58] = shahs[(Y0 - 31) / 58, (X0 - 17) / 58];
                    shahs[(Y0 - 31) / 58, (X0 - 17) / 58] = 0;
                    checkDamkas((y - 31) / 58, (x - 17) / 58);
                    turns = (turns + 1) % 2;
                    rublys = rubls();


                    shashki[index, j + 1] = 2;

                    if ((rublys == 1) && (DamkaNoComps == 0))
                    {
                        shashki[index, j + 1] = 1;
                    }
                    else if ((fdamka == 0) && (damkas[shahs[(y - 31) / 58, (x - 17) / 58] - 1] == 1))
                    {
                        shashki[index, j + 1] = 3;
                    }

                    if (al == 4)
                    {
                        shashki[index, j + 1] = 4;
                    }

                    if ((blackCounts == 0) || (whiteCounts == 0))
                    {
                        shashki[index, j + 1] = 5;
                    }
                    if (priora < shashki[index, j + 1]) priora = shashki[index, j + 1];
                    //if (GameIsOver != 1) { if (computer == 1) comp(); checkAbility(); }
                }
                else shashki[index, j + 1] = 0;
            }
            index++;
        }

        private int cAllowForCheck(Button s)
        {
            int x = (s.Location.X - 17) / 58,
                y = (s.Location.Y - 31) / 58,
                i, j;

            if (turn == 0)
            {
                if (direction == 0)
                {
                    int ret = 0;
                    for (int ii = 0; ii < 8; ii++)
                    {
                        i = hodi[ii, 0];
                        j = hodi[ii, 1];
                        if (((x + i) < 0) || ((x + i) > 7) || ((y + j) < 0) || ((y + j) > 7)) { ret++; continue; }
                        if (rubly == 1)
                        {
                            if (rub[shah[y, x] - 1] == 0) { ret++; continue; }
                            else
                            {
                                if ((((x + (x + i)) / 2) == (x + i)) || (((x + (x + i)) / 2) == x) || (((y + (y + j)) / 2) == (y + j)) || (((y + (y + j)) / 2) == y)) { ret++; continue; }
                            }
                        }
                        if (shah[y, x] > 12) { ret++; continue; }
                        if (((x + i) == x) || ((y + j) == y)) { ret++; continue; }
                        if (shah[(y + j), (x + i)] != 0) { ret++; continue; }
                        if ((((x + (x + i)) / 2) != (x + i)) && (((x + (x + i)) / 2) != x) && (((y + (y + j)) / 2) != (y + j)) && (((y + (y + j)) / 2) != y))
                        {
                            if ((damka[shah[y, x] - 1] == 1) && (((y - (y + j)) > 2) || (((y - (y + j)) < -2)))) { ret++; continue; }
                            if ((damka[shah[y, x] - 1] == 0) && ((y + j) > y)) { ret++; continue; }
                            if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] > 12)
                            {
                                if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] == 0) { ret++; continue; }
                                return 1;
                            }
                        }
                        if (((y - (y + j) != 1) && (damka[shah[y, x] - 1] == 0)) || (x - (x + i) > 1) || ((x + i) - x > 1)) { ret++; continue; }

                    }
                    if (ret == 8) return 0; else return 1;
                }
                else
                {
                    int ret = 0;
                    for (int ii = 0; ii < 8; ii++)
                    {
                        i = hodi[ii, 0];
                        j = hodi[ii, 1];
                        if (((x + i) < 0) || ((x + i) > 7) || ((y + j) < 0) || ((y + j) > 7)) { ret++; continue; }
                        if (rubly == 1)
                        {
                            if (rub[shah[y, x] - 1] == 0) { ret++; continue; }
                            else
                            {
                                if ((((x + (x + i)) / 2) == (x + i)) || (((x + (x + i)) / 2) == x) || (((y + (y + j)) / 2) == (y + j)) || (((y + (y + j)) / 2) == y)) { ret++; continue; }
                            }
                        }
                        if (shah[y, x] < 13) { ret++; continue; }
                        if (((x + i) == x) || ((y + j) == y)) { ret++; continue; }
                        if (shah[(y + j), (x + i)] != 0) { ret++; continue; }
                        if ((((x + (x + i)) / 2) != (x + i)) && (((x + (x + i)) / 2) != x) && (((y + (y + j)) / 2) != (y + j)) && (((y + (y + j)) / 2) != y))
                        {
                            if ((damka[shah[y, x] - 1] == 1) && (((y - (y + j)) > 2) || (((y - (y + j)) < -2)))) { ret++; continue; }
                            if ((damka[shah[y, x] - 1] == 0) && ((y + j) < y)) { ret++; continue; }
                            if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] < 13)
                            {
                                if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] == 0) { ret++; continue; }
                                return 1;
                            }
                        }
                        if (((y - (y + j) != -1) && (damka[shah[y, x] - 1] == 0)) || (x - (x + i) > 1) || ((x + i) - x > 1)) { ret++; continue; }
                    }
                    if (ret == 8) return 0; else return 1;
                }
            }
            else
            {
                if (direction == 0)
                {
                    int ret = 0;
                    for (int ii = 0; ii < 8; ii++)
                    {
                        i = hodi[ii, 0];
                        j = hodi[ii, 1];
                        if (((x + i) < 0) || ((x + i) > 7) || ((y + j) < 0) || ((y + j) > 7)) { ret++; continue; }
                        if (rubly == 1)
                        {
                            if (rub[shah[y, x] - 1] == 0) { ret++; continue; }
                            else
                            {
                                if ((((x + (x + i)) / 2) == (x + i)) || (((x + (x + i)) / 2) == x) || (((y + (y + j)) / 2) == (y + j)) || (((y + (y + j)) / 2) == y)) { ret++; continue; }
                            }
                        }
                        if (shah[y, x] < 13) { ret++; continue; }
                        if (((x + i) == x) || ((y + j) == y)) { ret++; continue; }
                        if (shah[(y + j), (x + i)] != 0) { ret++; continue; }
                        if ((((x + (x + i)) / 2) != (x + i)) && (((x + (x + i)) / 2) != x) && (((y + (y + j)) / 2) != (y + j)) && (((y + (y + j)) / 2) != y))
                        {
                            if ((damka[shah[y, x] - 1] == 1) && (((y - (y + j)) > 2) || (((y - (y + j)) < -2)))) { ret++; continue; }
                            if ((damka[shah[y, x] - 1] == 0) && ((y + j) < y)) { ret++; continue; }
                            if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] < 13)
                            {
                                if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] == 0) { ret++; continue; }
                                return 1;
                            }
                        }
                        if (((y - (y + j) != -1) && (damka[shah[y, x] - 1] == 0)) || (x - (x + i) > 1) || ((x + i) - x > 1)) { ret++; continue; }
                    }
                    if (ret == 8) return 0; else return 1;
                }
                else
                {
                    int ret = 0;
                    for (int ii = 0; ii < 8; ii++)
                    {
                        i = hodi[ii, 0];
                        j = hodi[ii, 1];
                        if (((x + i) < 0) || ((x + i) > 7) || ((y + j) < 0) || ((y + j) > 7)) { ret++; continue; }
                        if (rubly == 1)
                        {
                            if (rub[shah[y, x] - 1] == 0) { ret++; continue; }
                            else
                            {
                                if ((((x + (x + i)) / 2) == (x + i)) || (((x + (x + i)) / 2) == x) || (((y + (y + j)) / 2) == (y + j)) || (((y + (y + j)) / 2) == y)) { ret++; continue; }
                            }
                        }
                        if (shah[y, x] > 12) { ret++; continue; }
                        if (((x + i) == x) || ((y + j) == y)) { ret++; continue; }
                        if (shah[(y + j), (x + i)] != 0) { ret++; continue; }
                        if ((((x + (x + i)) / 2) != (x + i)) && (((x + (x + i)) / 2) != x) && (((y + (y + j)) / 2) != (y + j)) && (((y + (y + j)) / 2) != y))
                        {
                            if ((damka[shah[y, x] - 1] == 1) && (((y - (y + j)) > 2) || (((y - (y + j)) < -2)))) { ret++; continue; }
                            if ((damka[shah[y, x] - 1] == 0) && ((y + j) > y)) { ret++; continue; }
                            if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] > 12)
                            {
                                if (shah[((y + (y + j)) / 2), ((x + (x + i)) / 2)] == 0) { ret++; continue; }
                                return 1;
                            }
                        }
                        if (((y - (y + j) != 1) && (damka[shah[y, x] - 1] == 0)) || (x - (x + i) > 1) || ((x + i) - x > 1)) { ret++; continue; }
                    }
                    if (ret == 8) return 0; else return 1;
                }
            }
        }

        private void checkAbility()
        {
            int allows = 0;
            for (int i = 1; i < 25; i++)
            {
                for (int ii = 0; ii < 8; ii++)
                {
                    for (int jj = 0; jj < 8; jj++)
                    {
                        if (shah[ii, jj] == i)
                        {
                            if (cAllowForCheck(shahOb[shah[ii, jj] - 1]) == 1)
                            {
                                allows = 1;
                            }
                        }
                    }
                }
            }
            if (allows == 0)
            {
                if (turn == 0)
                {
                    whiteCount = 0;
                    gameover();
                }
                else
                {
                    blackCount = 0;
                    gameover();
                }
            }
        }

        private void DoWork()
        {
            Thread.Sleep(1200);
            this.Update();
        }

        private void comp()
        {
            if (DamkaNoComp == 1)
            {
                DamkaNoComp = 0;
                return;
            }
            if (DamkaNoComp == 2)
            {
                DamkaNoComp = 0;
            }
            if (GameIsOver == 0) checkAbility();
            if (GameIsOver == 1) return;
            index = 0;
            DoWork();
            priora = 0;
            shashki = new int[12, 9] { { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
            

            for (int i = 1; i < 25; i++)
            {
                for (int ii = 0; ii < 8; ii++)
                {
                    for (int jj = 0; jj < 8; jj++)
                    {
                        if (shah[ii, jj] == i)
                        {
                            if (((i <= 12) && (i > 0) && (((turn + direction) % 2) == 0)) || ((i < 25) && (i > 12) && (((turn + direction) % 2) == 1)))
                            {
                                shashki[index, 0] = i;
                                cAllow(shahOb[i - 1]);
                            }
                        }
                    }
                }
            }

            int num, hod;
            int[] pr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int prI = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (shashki[i, j] == priora)
                    {
                        pr[prI++] = i;
                        break;
                    }
                }
            }
            num = rnd.Next(0, prI - 1);
            num = pr[num];
            x0 = shahOb[shashki[num, 0] - 1].Location.X;
            y0 = shahOb[shashki[num, 0] - 1].Location.Y;
            int x, y;
            int[] priors = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int prInd = 0;
            for (int i = 1; i < 9; i++) if (shashki[num, i] == priora) { priors[prInd++] = i; }
                hod = rnd.Next(0, prInd - 1);
                hod = priors[hod] - 1;
                x = x0 + 58 * hodi[hod, 0];
                y = y0 + 58 * hodi[hod, 1];
            allow(x, y);
            shahOb[shashki[num, 0] - 1].Location = new Point(x, y);
            DownPoint = new Point();
            shah[(y - 31) / 58, (x - 17) / 58] = shashki[num, 0];
            shah[(y0 - 31) / 58, (x0 - 17) / 58] = 0;
            checkDamka((y - 31) / 58, (x - 17) / 58);
            turn = (turn + 1) % 2;
            if ((blackCount == 0) || (whiteCount == 0)) gameover();
            rubly = rubl();
            shahOb[shashki[num, 0] - 1].BringToFront();
            checkAbility();
            if (DamkaNoComp == 1)
            {
                DamkaNoComp = 2;
                comp();
            }
        }

        private void gameover()
        {
            if (GameIsOver == 1) return;
            GameIsOver = 1;
            Form game = new gameover();
            if (whiteCount == 0)
                game.BackgroundImage = Image.FromFile("bin\\images\\blackWin.png");
            if (blackCount == 0)
                game.BackgroundImage = Image.FromFile("bin\\images\\whiteWin.png");
            game.ShowDialog();
        }
        public okno()
        {
            InitializeComponent();
            setShahPosition();
            shahOb[0] = shashka1;
            shahOb[1] = shashka2;
            shahOb[2] = shashka3;
            shahOb[3] = shashka4;
            shahOb[4] = shashka5;
            shahOb[5] = shashka6;
            shahOb[6] = shashka7;
            shahOb[7] = shashka8;
            shahOb[8] = shashka9;
            shahOb[9] = shashka10;
            shahOb[10] = shashka11;
            shahOb[11] = shashka12;
            shahOb[12] = shashka13;
            shahOb[13] = shashka14;
            shahOb[14] = shashka15;
            shahOb[15] = shashka16;
            shahOb[16] = shashka17;
            shahOb[17] = shashka18;
            shahOb[18] = shashka19;
            shahOb[19] = shashka20;
            shahOb[20] = shashka21;
            shahOb[21] = shashka22;
            shahOb[22] = shashka23;
            shahOb[23] = shashka24;
            тестToolStripMenuItem.Visible = false;
            center = this.Location;
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
            shashka1.Visible = false;
            shashka2.Visible = false;
            shashka3.Visible = false;
            shashka4.Visible = false;
            shashka5.Visible = false;
            shashka6.Visible = false;
            shashka7.Visible = false;
            shashka8.Visible = false;
            shashka9.Visible = false;
            shashka10.Visible = false;
            shashka11.Visible = false;
            shashka12.Visible = false;
            shashka13.Visible = false;
            shashka14.Visible = false;
            shashka15.Visible = false;
            shashka16.Visible = false;
            shashka17.Visible = false;
            shashka18.Visible = false;
            shashka19.Visible = false;
            shashka20.Visible = false;
            shashka21.Visible = false;
            shashka22.Visible = false;
            shashka23.Visible = false;
            shashka24.Visible = false;

        }

        /* 1 - MouseDown, 2 - MouseUp, 3 - MouseMove. */
        private void shashka_move(int arg, int numb, MouseEventArgs e)
        {
            if(arg == 0)
            {
                DownPoint = e.Location;
                ArinaBugHunter(numb);
                clicks[numb] = 1;
                x0 = shahOb[numb].Location.X;
                y0 = shahOb[numb].Location.Y;
                shahOb[numb].BringToFront();
                return;
            }
            if (arg == 1)
            {
                clicks[numb] = 0;
                int x, y;
                x = shahOb[numb].Location.X;
                y = shahOb[numb].Location.Y;
                x = ((x + 12) / 58) * 58 + 17;
                y = ((y - 2) / 58) * 58 + 31;
                if (allow(x, y) == 1)
                {
                    shahOb[numb].Location = new Point(x, y);
                    DownPoint = new Point();
                    shah[(y - 31) / 58, (x - 17) / 58] = numb + 1;
                    shah[(y0 - 31) / 58, (x0 - 17) / 58] = 0;
                    checkDamka((y - 31) / 58, (x - 17) / 58);
                    turn = (turn + 1) % 2;
                    if ((blackCount == 0) || (whiteCount == 0)) gameover();
                    rubly = rubl();
                    if (GameIsOver != 1) { if (computer == 1) comp(); checkAbility(); }
                }
                else
                {
                    shahOb[numb].Location = new Point(x0, y0);
                }
                return;
            }
            if (arg == 2)
            {
                if (clicks[numb] == 1)
                {
                    Point dp = new Point(e.Location.X - DownPoint.X, e.Location.Y - DownPoint.Y);
                    shahOb[numb].Location = new Point(shahOb[numb].Location.X + dp.X, shahOb[numb].Location.Y + dp.Y);
                }
                return;
            }
        }

        private void shashka1_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 0, e);
        }
        private void shashka2_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 1, e);
        }
        private void shashka3_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 2, e);
        }
        private void shashka4_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 3, e);
        }
        private void shashka5_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 4, e);
        }
        private void shashka6_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 5, e);
        }
        private void shashka7_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 6, e);
        }
        private void shashka8_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 7, e);
        }
        private void shashka9_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 8, e);
        }
        private void shashka10_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 9, e);
        }
        private void shashka11_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 10, e);
        }
        private void shashka12_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 11, e);
        }
        private void shashka13_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 12, e);
        }
        private void shashka14_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 13, e);
        }
        private void shashka15_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 14, e);
        }
        private void shashka16_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 15, e);
        }
        private void shashka17_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 16, e);
        }
        private void shashka18_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 17, e);
        }
        private void shashka19_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 18, e);
        }
        private void shashka20_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 19, e);
        }
        private void shashka21_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 20, e);
        }
        private void shashka22_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 21, e);
        }
        private void shashka23_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 22, e);
        }
        private void shashka24_MouseDown(object sender, MouseEventArgs e)
        {
            shashka_move(0, 23, e);
        }


        private void shashka1_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 0, e);
        }
        private void shashka2_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 1, e);
        }
        private void shashka3_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 2, e);
        }
        private void shashka4_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 3, e);
        }
        private void shashka5_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 4, e);
        }
        private void shashka6_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 5, e);
        }
        private void shashka7_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 6, e);
        }
        private void shashka8_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 7, e);
        }
        private void shashka9_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 8, e);
        }
        private void shashka10_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 9, e);
        }
        private void shashka11_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 10, e);
        }
        private void shashka12_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 11, e);
        }
        private void shashka13_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 12, e);
        }
        private void shashka14_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 13, e);
        }
        private void shashka15_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 14, e);
        }
        private void shashka16_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 15, e);
        }
        private void shashka17_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 16, e);
        }
        private void shashka18_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 17, e);
        }
        private void shashka19_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 18, e);
        }
        private void shashka20_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 19, e);
        }
        private void shashka21_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 20, e);
        }
        private void shashka22_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 21, e);
        }
        private void shashka23_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 22, e);
        }
        private void shashka24_MouseUp(object sender, MouseEventArgs e)
        {
            shashka_move(1, 23, e);
        }


        private void shashka1_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 0, e);
        }
        private void shashka2_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 1, e);
        }
        private void shashka3_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 2, e);
        }
        private void shashka4_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 3, e);
        }
        private void shashka5_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 4, e);
        }
        private void shashka6_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 5, e);
        }
        private void shashka7_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 6, e);
        }
        private void shashka8_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 7, e);
        }
        private void shashka9_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 8, e);
        }
        private void shashka10_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 9, e);
        }
        private void shashka11_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 10, e);
        }
        private void shashka12_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 11, e);
        }
        private void shashka13_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 12, e);
        }
        private void shashka14_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 13, e);
        }
        private void shashka15_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 14, e);
        }
        private void shashka16_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 15, e);
        }
        private void shashka17_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 16, e);
        }
        private void shashka18_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 17, e);
        }
        private void shashka19_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 18, e);
        }
        private void shashka20_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 19, e);
        }
        private void shashka21_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 20, e);
        }
        private void shashka22_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 21, e);
        }
        private void shashka23_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 22, e);
        }
        private void shashka24_MouseMove(object sender, MouseEventArgs e)
        {
            shashka_move(2, 23, e);
        }

        private void ArinaBugHunter(int Number)
        {
            if (Number == 500)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (shah[y, x] > 0)
                        {
                            shahOb[shah[y, x] - 1].Location = new Point((x * 58) + 17, (y * 58) + 31);
                            shahOb[shah[y, x] - 1].Visible = true;
                        }
                    }
                }
                return;
            }
            for(int i=0; i < 24; i++)
            {
                if ((clicks[i] == 1) && (i != Number))
                {
                    for (int j = 0; j < 24; j++)
                    {
                        clicks[j] = 0;
                    }
                    for(int x = 0; x < 8; x++)
                    {
                        for(int y = 0; y < 8; y++)
                        {
                            if (shah[y, x] > 0)
                            {
                                shahOb[shah[y, x] - 1].Location = new Point((x * 58) + 17, (y * 58) + 31);
                            }
                        }
                    }

                    return;
                }
            }
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

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("bin\\rools.txt");
        }

        private void setShahPosition()
        {
            DamkaNoComp = 0;
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

        private void белыеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GameIsOver = 0;
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
            rubly = 0;
            for (int i = 0; i < 24; i++) { rub[i] = 0; damka[i] = 0; }
            computer = 1;
        }

        private void компьютерКомпьютерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameIsOver = 0;
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
            rubly = 0;
            for (int i = 0; i < 24; i++) { rub[i] = 0; damka[i] = 0; }
            computer = 1;
            rubl();
            while (GameIsOver != 1)
            {
                comp();
            }
        }

        private void черныеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GameIsOver = 0;
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
            rubly = 0;
            for (int i = 0; i < 24; i++) { rub[i] = 0; damka[i] = 0; }
            computer = 1;
            rubl();
            comp();
        }

        private void сДругомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameIsOver = 0;
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
            rubly = 0;
            for (int i = 0; i < 24; i++) { rub[i] = 0; damka[i] = 0; }
            computer = 0;
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("bin\\Readme.txt");
        }
        private void белыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameIsOver = 0;
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
            rubly = 0;
            for (int i = 0; i < 24; i++) { rub[i] = 0; damka[i] = 0; }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void черныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameIsOver = 0;
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
            rubly = 0;
            for (int i = 0; i < 24; i++) { rub[i] = 0; damka[i] = 0; }
        }

        private void notAllowedMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            тестToolStripMenuItem.Visible = false; 
            shashka1.Visible = false;
            shashka2.Visible = false;
            shashka3.Visible = false;
            shashka4.Visible = false;
            shashka5.Visible = false;
            shashka6.Visible = false;
            shashka7.Visible = false;
            shashka8.Visible = false;
            shashka9.Visible = false;
            shashka10.Visible = false;
            shashka11.Visible = false;
            shashka12.Visible = false;
            shashka13.Visible = false;
            shashka14.Visible = false;
            shashka15.Visible = false;
            shashka16.Visible = false;
            shashka17.Visible = false;
            shashka18.Visible = false;
            shashka19.Visible = false;
            shashka20.Visible = false;
            shashka21.Visible = false;
            shashka22.Visible = false;
            shashka23.Visible = false;
            shashka24.Visible = false;
            shah = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };
            shah[7, 6] = 1;
            shah[6, 7] = 13;
            shah[4, 3] = 2;
            ArinaBugHunter(500);
            if ((computer == 1) && (direction == 1))
            {
                turn = 0;
                comp();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(522, 550);
            this.Location = center;
            тестToolStripMenuItem.Visible = true;
        }
    }
}