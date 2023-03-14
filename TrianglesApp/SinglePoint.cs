using System.Drawing;

namespace TrianglesApp
{
    internal class SinglePoint
    {
        int x, y;

        public SinglePoint()
        {
            x = 0;
            y = 0;
        }

        public SinglePoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public SolidBrush brush { get; set; }

        public void Draw(Graphics g, int r)
        {
            g.FillEllipse(brush, this.X - r, this.Y - r, 2 * r, 2 * r);
        }

        public virtual void Move(int h1, int h2)
        {
            this.X += h1;
            this.Y += h2;
        }

    }
}
