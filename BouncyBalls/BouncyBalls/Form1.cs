using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace BouncyBalls
{
    public partial class Form1 : Form
    {
        private CDrawer _canvas = new CDrawer();

        List<Cball> cBalls = new List<Cball>();
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            _canvas.ContinuousUpdate = false;
        }

        private void UI_RandomBtn_Click(object sender, EventArgs e)
        {
            int randX = rand.Next(-5, 5);
            int randY = rand.Next(-5, 5);

            while (randX == randY || randX == 0 || randY == 0)
            {
                randX = rand.Next(-5, 5);
                randY = rand.Next(-5, 5);
            }

            Cball randomBall = new Cball(Color.LightPink, new Point(randX, randY));
            cBalls.Add(randomBall);
        }

        private void UI_Btn_AddHyperBall_Click(object sender, EventArgs e)
        {
            Cball hyperBall = new Cball(RandColor.GetColor());
            cBalls.Add(hyperBall);
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            _canvas.Clear();
     
            for (int i = 0; i < cBalls.Count; i++)
            {
                cBalls[i].Move();
                cBalls[i].Render(_canvas);
            }
        }
    }
}
