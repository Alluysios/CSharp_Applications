using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using GDIDrawer;

namespace Brownians_Balls
{
    public partial class Form1 : Form
    {
        Bitmap img;
        Thread th;

        List<SBall> tBalls = new List<SBall>();
        List<SBall> rBalls = new List<SBall>();

        struct SBall
        {
            public PointF _pos;
            public Color _colour;

            public SBall(PointF _pos, Color _colour)
            {
                this._pos = _pos;
                this._colour = _colour;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileBtn(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image File|*.PNG";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(ofd.FileName);

                UI_FileDirText.Text = ofd.FileName;
                UI_ImgLoadBox.Image = img;
                CDrawer canvas = new CDrawer(1000, 1000);

                //Iterate whole bitmap
                for (int i = 0; i < UI_ImgLoadBox.Image.Height; i++)
                {
                    for (int j = 0; j < UI_ImgLoadBox.Image.Width; j++)
                    {
                        // Color of current pixel
                        Color curColor = img.GetPixel(j, i);


                        // Target
                        if (int.Parse(curColor.A.ToString()) != 255 &&
                            (int.Parse(curColor.R.ToString()) >= 255 ||
                            int.Parse(curColor.G.ToString()) >= 255 ||
                            int.Parse(curColor.B.ToString()) >= 255))
                        {

                            SBall target;
                            target._pos = new PointF(j, i);
                            target._colour = curColor;
                            tBalls.Add(target);

                        }

                        // Regular
                        if (int.Parse(curColor.A.ToString()) >= 255)
                        {

                            SBall colorBalls;
                            colorBalls._pos = new PointF(j, i);
                            colorBalls._colour = curColor;
                            rBalls.Add(colorBalls);
                        }
                    }
                }
            }
        }

        private void startSimulBtn(object sender, EventArgs e)
        {
            // Track target position and color
            Console.WriteLine(tBalls.Count + "Target balls");
            Console.WriteLine(rBalls.Count + "Regular balls");

            th = new Thread(() => simulateBalls(rBalls, tBalls));
            th.IsBackground = true;
            th.Start();
        }

        void simulateBalls(List<SBall> regularBalls, List<SBall> targetBalls)
        {
            // non-target balls move closer to target balls -x -y
            // loop each regular ball

            for (int i = 0; i < rBalls.Count; i++)
            {

                for (int t = 0; t < tBalls.Count; t++)
                {
                    if (rBalls[i]._colour.R == tBalls[t]._colour.R)
                    {
                        if (rBalls[i]._pos.X < tBalls[t]._pos.X)
                        {
                            PointF point = new PointF(rBalls[i]._pos.X + 10, rBalls[i]._pos.Y);
                            SBall newBall = new SBall(point, rBalls[i]._colour);
                            rBalls[i] = newBall;
                        }
                        continue;
                    }

                    if (rBalls[i]._colour.G == tBalls[t]._colour.G)
                    {
                        continue;
                    }

                    if (rBalls[i]._colour.B == tBalls[t]._colour.B)
                    {
                        continue;
                    }
                }

                Thread.Sleep(10);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}