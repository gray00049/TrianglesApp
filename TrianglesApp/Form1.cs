using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrianglesApp
{
    public partial class Form1 : Form
    {
        Random r = new Random();

        Triangle[] triangles;

        int k = 10;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
            {
                MessageBox.Show("Номер треугольника должен быть положительным!");
                return;
            }
            k = (int)numericUpDown3.Value;
            int h1 = -r.Next(1, 10);
            ChangeIfIntersect(triangles, k, ref h1, "up");
            triangles[k - 1].Move(0, h1);
            DrawTriangles();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
            {
                MessageBox.Show("Номер треугольника должен быть положительным!");
                return;
            }
            k = (int)numericUpDown3.Value;
            int h1 = r.Next(1, 10);
            ChangeIfIntersect(triangles, k, ref h1, "bottom");
            triangles[k - 1].Move(0, h1);
            DrawTriangles();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
            {
                MessageBox.Show("Номер треугольника должен быть положительным!");
                return;
            }
            k = (int)numericUpDown3.Value;
            int h1 = -r.Next(1, 10);
            ChangeIfIntersect(triangles, k, ref h1, "left");
            triangles[k - 1].Move(h1, 0);
            DrawTriangles();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
            {
                MessageBox.Show("Номер треугольника должен быть положительным!");
                return;
            }
            k = (int)numericUpDown3.Value;
            int h1 = r.Next(1, 10);
            ChangeIfIntersect(triangles, k, ref h1, "right");
            triangles[k - 1].Move(h1, 0);
            DrawTriangles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Номер треугольника должен быть положительным!");
                return;
            }
            int n = (int)numericUpDown1.Value;
            triangles = new Triangle[n];
            for (int i = 0; i < n; i++)
            {
                triangles[i] = GetRandomTriangle();
            }
            DrawTriangles();
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            numericUpDown2.Maximum = n;
            numericUpDown3.Maximum = n;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == numericUpDown1.Maximum)
            {
                MessageBox.Show("Достигнуто максимальное число треугольников!");
                return;
            }
            else
            {
                Triangle tr = GetRandomTriangle();
                Array.Resize(ref triangles, triangles.Length + 1);
                triangles[triangles.GetUpperBound(0)] = tr;
                numericUpDown1.Value++;
                numericUpDown2.Maximum = triangles.Length;
                numericUpDown3.Maximum = triangles.Length;
                DrawTriangles();
            }
        }

        private void ChangeIfIntersect(Triangle[] triangles, int k, ref int h, string buttonDirection)
        {
            int x1 = triangles[k - 1].X;
            int y1 = triangles[k - 1].Y;
            int x2 = triangles[k - 1].point2.X;
            int y2 = triangles[k - 1].point2.Y;
            int x3 = triangles[k - 1].point3.X;
            int y3 = triangles[k - 1].point3.Y;

            if (buttonDirection == "bottom" && 
                (y1 + h >= pictureBox1.Height || 
                y2 + h >= pictureBox1.Height || 
                y3 + h >= pictureBox1.Height))
            {
                h = -10;
            }

            if (buttonDirection == "up" && 
                (y1 + h <= 0 
                || y2 + h <= 0 
                || y3 + h <= 0))
            {
                h = 10;
            }

            if (buttonDirection == "right" && 
                (x1 + h >= pictureBox1.Width ||
                x2 + h >= pictureBox1.Width ||
                x3 + h >= pictureBox1.Width))
            {
                h = -10;
            }

            if (buttonDirection == "left" && 
                (x1 + h <= 0 ||
                x2 + h <= 0 ||
                x3 + h <= 0))
            {
                h = 10;
            }
        }

        Triangle GetRandomTriangle()
        {
            int x1 = r.Next(0, pictureBox1.Width);
            int y1 = r.Next(0, pictureBox1.Height);
            int x2 = r.Next(0, pictureBox1.Width);
            int y2 = r.Next(0, pictureBox1.Height);
            int x3 = r.Next(0, pictureBox1.Width);
            int y3 = r.Next(0, pictureBox1.Height);

            SinglePoint point1 = new SinglePoint(x1, y1);
            SinglePoint point2 = new SinglePoint(x2, y2);
            SinglePoint point3 = new SinglePoint(x3, y3);

            Color randomColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));

            point1.brush = new SolidBrush(randomColor);

            return new Triangle(point1, point2, point3 );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0)
            {
                MessageBox.Show("Номер треугольника должен быть положительным!");
                return;
            }
            if (timer1.Enabled)
                timer1.Stop();
            k = (int)numericUpDown2.Value;
            var trList = triangles.ToList();
            trList.RemoveAt(k - 1);
            triangles = trList.ToArray();
            DrawTriangles();
            numericUpDown2.Value--;
            numericUpDown2.Maximum = triangles.Length;
            numericUpDown3.Maximum = triangles.Length;
            numericUpDown1.Value--;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0)
            {
                MessageBox.Show("Номер треугольника должен быть положительным!");
                return;
            }
            if (timer1.Enabled)
                timer1.Stop();
            else
            {
                timer1.Start();
                k = (int)numericUpDown2.Value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = r.Next(-10, 10);
            int y = r.Next(-10, 10);

            int selectedTriangle = Convert.ToInt32(numericUpDown2.Value);

            if (x < 0)
            {
                ChangeIfIntersect(triangles, selectedTriangle, ref x, "left");
            } else
            {
                ChangeIfIntersect(triangles, selectedTriangle, ref x, "right");
            }

            if (y < 0)
            {
                ChangeIfIntersect(triangles, selectedTriangle, ref y, "up");
            }
            else
            {
                ChangeIfIntersect(triangles, selectedTriangle, ref y, "bottom");
            }

            triangles[selectedTriangle - 1].Move(x, 0);
            triangles[selectedTriangle - 1].Move(0, y);
            DrawTriangles();
        }

        void DrawTriangles()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (var g = Graphics.FromImage((Bitmap)pictureBox1.Image))
            {
                for (int i = 0; i < triangles.Length; i++)
                {
                    triangles[i].Draw(g);
                }
                pictureBox1.Refresh();

            }
        }

    }
}