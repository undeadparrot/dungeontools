using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PerspectiveTester
{
    public partial class ProjectorForm : Form
    {
        private MainForm MainForm;

        public ProjectorForm(MainForm _form)
        {
            MainForm = _form;
            InitializeComponent();
        }

        private void WindowProjector_Load(object sender, EventArgs e)
        {
        }
        private void pnlProjection_Paint(object sender, PaintEventArgs e)
        {
            Draw();

        }

        public void Draw()
        {
            var g = pnlProjection.CreateGraphics();
            g.Clear(Color.Lavender);

            if (MainForm.referencePic != null && MainForm.chkRefPic.Checked)
            {
                g.DrawImage(MainForm.referencePic, 0, 0);
            }

            var penDot = new Pen(Color.CadetBlue);
            penDot.Width = 2.0F;
            var brushDot = new SolidBrush(penDot.Color);
            var brushWallLeft = new SolidBrush(Color.FromArgb(101, Color.Gold));
            var brushWallFront = new SolidBrush(Color.FromArgb(47, Color.ForestGreen));
            var brushWallRight = new SolidBrush(Color.FromArgb(101, Color.DeepSkyBlue));

            var penLine = new Pen(Color.FromArgb(101, Color.Aquamarine));
            var penOutline = new Pen(Color.FromArgb(255, Color.ForestGreen));

            var depth = 7;

            for (int i = -depth; i <= depth; i++)
            //for (int i = 0; i < 1; i++)
            {

                for (int j = -depth; j <= depth; j++)
                //for (int i = 0; i < 1; i++)
                {
                    var x = i * (MainForm.GetWidth() * 2);
                    ;
                    //x += GetWidth()/2F;
                    var z = j * (MainForm.GetWidth() * 2);
                    ;
                    var y = 0;

                    var name = MainForm.MakeName(j + depth, i);
                    if (!MainForm.BlockVisibleByName(name))
                    {
                        continue;
                    }

                    var cube = new Cube(MainForm.GetTranslateX() + x, MainForm.GetTranslateY() + y, z);
                    MainForm.GeneratePoints(cube);
                    MainForm.TransformPoints(cube.Points);
                    if (MainForm.chkDrawLines.Checked)
                    {
                        MainForm.DrawPoints(g, cube.Points, penLine);
                    }
                    if (MainForm.chkDrawLeft.Checked)
                    {
                        MainForm.DrawWall(g, cube.FetchLeft, penOutline, brushWallLeft);
                    }
                    if (MainForm.chkDrawRight.Checked)
                    {
                        MainForm.DrawWall(g, cube.FetchRight, penOutline, brushWallRight);
                    }
                    if (MainForm.chkDrawFront.Checked)
                    {
                        MainForm.DrawWall(g, cube.FetchFront, penOutline, brushWallFront);
                    }
                }

            }

        }
    }
}
