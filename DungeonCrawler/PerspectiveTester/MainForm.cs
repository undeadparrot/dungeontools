using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace PerspectiveTester
{
    public partial class MainForm : Form
    {
        private ProjectorForm Projector;
        private List<Point3DF> _Points;
        private float w { get { return Projector.pnlProjection.Width; } }
        private float h { get { return Projector.pnlProjection.Height; } }
        public Image referencePic;
        public MainForm()
        {
            InitializeComponent();

            Projector=new ProjectorForm(this);
            Projector.Show();

            PopulateGroupButtonMatrix();

            sliderProjectorWidth.Value = 320;
            sliderProjectorHeight.Value = 240;
            Projector.Width = 320;
            Projector.Height = 240;
            Projector.pnlProjection.Width = 320;
            Projector.pnlProjection.Height = 240;

        }

        private void PopulateGroupButtonMatrix()
        {
            var s = 25;
            for (int i = 0; i < 5; i++)
            {
                for (int j = -(i+1); j <= (i+1); j++)
                {
                    var butt = new Button();
                    butt.Width = s;
                    butt.Height = s;
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.Padding = new Padding(0);
                    butt.Font=new Font(butt.Font.FontFamily,5);
                    butt.Top = groupButtonMatrix.Height - (s*2) - (i*(s + 3));
                    butt.Left = (groupButtonMatrix.Width/2) - (s/2) + (j*(s+3));
                    butt.Click+=BtnMatrixOnClick;
                    butt.BackColor = Color.DarkGray;
                    var name = MakeName(i, j);
                    butt.Text = name;
                    butt.Name = "btnBlock" + name;
                    groupButtonMatrix.Controls.Add(butt);
                }
            }
        }

        public static string MakeName(int distance, int strafe)
        {
            var name = distance.ToString();
            if (strafe > 0)
            {
                name += "R" + strafe.ToString();
            }
            else if (strafe < 0)
            {
                name += "L" + (Math.Abs(strafe)).ToString();
            }
            return name;
        }

        private void BtnMatrixOnClick(object sender, EventArgs eventArgs)
        {
            var btn = (Button) sender;
            if(btn.BackColor == Color.DarkGray)
            {
                btn.BackColor = Color.LightYellow;
            }
            else
            {
                btn.BackColor = Color.DarkGray;
            }
            Projector.Draw();
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Projector.Draw();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Projector.Draw();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Projector.Draw();
        }
        private void slider3dScale_Scroll(object sender, EventArgs e)
        {
            Projector.Draw();
        }

        private void sliderHeight_Scroll(object sender, EventArgs e)
        {
            Projector.Draw();
        }
        private void sliderTranslateY_Scroll(object sender, EventArgs e)
        {
            Projector.Draw();
        }

        private void sliderTranslateX_Scroll(object sender, EventArgs e)
        {
            Projector.Draw();
        }


        public bool BlockVisibleByName(String name)
        {
            var controlName = "btnBlock" + name;
            if (groupButtonMatrix.Controls[controlName]!=null)
            {
                return groupButtonMatrix.Controls[controlName].BackColor == Color.LightYellow;
            }
            return false;
        }

        public void DrawWall(Graphics g, List<Point3DF> points, Pen pen,Brush brush)
        {


            var polygon = new List<PointF>();

            foreach (var p in points)
            {

                polygon.Add(new PointF(p.X, p.Y));

                var brushDotDepth = new SolidBrush(Color.FromArgb((int)Math.Min(p.Z * p.Z * 1.5, 255), Color.MediumBlue));
            }


            if (chkShade.Checked)
            {
                g.FillPolygon(brush, polygon.ToArray());
            }
            else
            {
                g.DrawPolygon(pen, polygon.ToArray());
            }

        }

        public void DrawPoints(Graphics g, List<Point3DF> points, Pen penLine)
        {

            var polygon = new List<PointF>();

            foreach (var op in points)
            {
                var p = op;

                polygon.Add(new PointF(p.X, p.Y));

                var brushDotDepth = new SolidBrush(Color.FromArgb((int)Math.Min(p.Z * p.Z * 1.5, 255), Color.MediumBlue));
                g.FillEllipse(brushDotDepth, p.X, p.Y, 5F, 5F);
            }

            var rng = new Random();

            if (chkDrawLines.Checked)
            {
                g.DrawPolygon(penLine, polygon.ToArray());
                //g.DrawPolygon(penLine, polygon.OrderBy(item => rng.Next()).ToArray());
                //g.DrawPolygon(penLine, polygon.OrderBy(item => rng.Next()).ToArray());
                //g.DrawPolygon(penLine, polygon.OrderBy(item => rng.Next()).ToArray());
            }
        }

        public void TransformPoints(List<Point3DF> points )
        {

            lblDebugOutput.Text = "";
            string original = "";
            string perspective = "\r\n\r\n";
            string projection = "\r\n\r\n";
            foreach (var op in points)
            {
                var p = op;
                original += string.Format("\r\n {0,8:F1} {1,8:F1} {2,8:F1}", p.X, p.Y, p.Z);
                p = (ProjectionTransformPoint(op)); //point is transformed originalpoint
                perspective += string.Format("\r\n {0,8:F1} {1,8:F1} {2,8:F1}", p.X, p.Y, p.Z);
                p = OffsetTransformPoint(p);
                projection += string.Format("\r\n {0,8:F1} {1,8:F1} {2,8:F1}", p.X, p.Y, p.Z);
            }
           
            lblDebugOutput.Text = original + perspective + projection;

        }

        public void GeneratePoints(Cube cube)
        {
            var tx = cube.X;
            var ty = cube.Y;
            var tz = cube.Z;
            var points = cube.Points;
            var sw = GetWidth();
            var sh = GetHeight();
            var sz = sw;
            var z = -GetDepth();
            points.Add(new Point3DF(-sw + tx, sh + ty, sz + z + tz));   //TopLeftBack
            points.Add(new Point3DF(sw + tx, sh + ty, sz + z + tz));    //TopRightBack
            points.Add(new Point3DF(sw + tx, -sh + ty, sz + z + tz));   //BottomRightBack
            points.Add(new Point3DF(-sw + tx, -sh + ty, sz + z + tz));  //BottomLeftBack

            points.Add(new Point3DF(-sw + tx, sh + ty, -sz + z + tz));  //TopLeftFront
            points.Add(new Point3DF(sw + tx, sh + ty, -sz + z + tz));   //TopRightFront
            points.Add(new Point3DF(sw + tx, -sh + ty, -sz + z + tz));  //BottomRightFront
            points.Add(new Point3DF(-sw + tx, -sh + ty, -sz + z + tz)); //BottomLeftFront


        }

        private Point3DF ProjectionTransformPoint(Point3DF op)
        {
            var p = op;

            p.X = p.X * Get3DScale();
            p.Y = p.Y * Get3DScale();
            p.Z = p.Z * Get3DScale();

            p.X = p.X * -1;
            p.Y = p.Y * 1F;
            p.Z = p.Z * 1F;

            var fov = h / w;
            var s = fov / (p.Z + fov);

            p.X = p.X * p.Z;// +(hw / p.Z);
            p.Y = p.Y * p.Z;// +(hh * p.Z);

            return p;
        }

        private Point3DF OffsetTransformPoint(Point3DF op)
        {
            var p = op;
            p.X = p.X * Get2DScale();
            p.Y = p.Y * Get2DScale();
            p.X = p.X + hw;
            p.Y = p.Y + hh;
            return p;
        }

        protected float hw
        {
            get { return (w / 2F); }
        }

        protected float hh
        {
            get { return (h / 2F); }
        }

        private float GetDepth()
        {
            var f = ((float)sliderDepth.Value) / 8F;
            return f;
        }
        private float Get2DScale()
        {
            return (float)slider2dScale.Value;
        }
        private float Get3DScale()
        {
            var f = ((float)slider3dScale.Value + 16F) / 16F;
            return f;
        }

        public float GetWidth()
        {
            return (float)sliderWidth.Value / 5F;
        }
        private float GetHeight()
        {
            return (float)sliderHeight.Value / 5F;
        }

        public float GetTranslateX()
        {
            return (float)sliderTranslateX.Value / 5F;
        }

        public float GetTranslateY()
        {
            return (float)sliderTranslateY.Value / 5F;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Projector.Draw();
        }

        private void chkDrawLines_CheckedChanged(object sender, EventArgs e)
        {
            Projector.Draw();
        }

        private void buttonReferencePic_Click(object sender, EventArgs e)
        {
            var log = new OpenFileDialog();
            if(log.ShowDialog()==DialogResult.OK)
            {
                referencePic=Image.FromFile(log.FileName);
            }
            Projector.Draw();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void chkRefPic_CheckedChanged(object sender, EventArgs e)
        {
            Projector.Draw();
        }

        private void buttonParseStringRequest_Click(object sender, EventArgs e)
        {

            foreach (var control in groupButtonMatrix.Controls)
            {
                var btn = (Button)control;
                if (control.GetType() == typeof(Button)  )
                {
                    btn.BackColor = Color.DarkGray;
                }
            }

            var json = JArray.Parse(txtJsonRequests.Text);
            foreach(var name in json)
            {
                groupButtonMatrix.Controls["btnBlock" + name].BackColor = Color.LightYellow;
            }

            Projector.Draw();

        }

        private void buttonSaveMatrixJson_Click(object sender, EventArgs e)
        {
            var json = new JArray();
            foreach (var control in groupButtonMatrix.Controls)
            {
                var btn = (Button)control;
                if (control.GetType() == typeof(Button) && btn.BackColor == Color.LightYellow)
                {
                    json.Add(btn.Name.Replace("btnBlock",""));
                }
            }
            txtJsonRequests.Text = json.ToString();
        }

        private void sliderProjectorWidth_Scroll(object sender, EventArgs e)
        {
            Projector.pnlProjection.Width = sliderProjectorWidth.Value;
            Projector.Width = sliderProjectorWidth.Value + 5;
            Projector.Draw();
        }

        private void sliderProjectorHeight_Scroll(object sender, EventArgs e)
        {
            Projector.pnlProjection.Height = sliderProjectorHeight.Value;
            Projector.Height = sliderProjectorHeight.Value+5;
            Projector.Draw();
        }


    }

    public class Point3DF
    {
        public float X;
        public float Y;
        public float Z;
        public Point3DF(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public void Translate(float _x, float _y, float _z)
        {
            X += _x;
            Y += _y;
            Z += _z;
        }
    }
    public class Cube
    {
        public float X;
        public float Y;
        public float Z;
        public List<Point3DF> Points;
        public Cube(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
            Points = new List<Point3DF>();
        }



        public Point3DF TopLeftBack { get { return Points[0]; } set { Points[0] = value; } }
        public Point3DF TopRightBack { get { return Points[1]; } set { Points[1] = value; } }
        public Point3DF BottomRightBack { get { return Points[2]; } set { Points[2] = value; } }
        public Point3DF BottomLeftBack { get { return Points[3]; } set { Points[3] = value; } }
        public Point3DF TopLeftFront { get { return Points[4]; } set { Points[4] = value; } }
        public Point3DF TopRightFront { get { return Points[5]; } set { Points[5] = value; } }
        public Point3DF BottomRightFront { get { return Points[6]; } set { Points[6] = value; } }
        public Point3DF BottomLeftFront { get { return Points[7]; } set { Points[7] = value; } }

        public List<Point3DF> FetchLeft
        {
            get
            {
                return new List<Point3DF>(){TopLeftBack,TopLeftFront,BottomLeftFront,BottomLeftBack};
            }
        }
        public List<Point3DF> FetchRight
        {
            get
            {
                return new List<Point3DF>() { TopRightFront, TopRightBack, BottomRightBack, BottomRightFront };
            }
        }
        public List<Point3DF> FetchFront
        {
            get
            {
                return new List<Point3DF>() { TopLeftFront, TopRightFront, BottomRightFront, BottomLeftFront };
            }
        }


    }
}
