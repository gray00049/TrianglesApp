using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesApp
{
    internal class Triangle : SolidLine
    {
        public Triangle(SinglePoint point1, SinglePoint point2, SinglePoint point3) : base(point1, point2)
        {
            this.point3 = new SinglePoint(point3.X, point3.Y);
        }

        public SinglePoint point3 { get; set; }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawLine(new Pen(brush.Color), X, Y, point3.X, point3.Y);
            g.DrawLine(new Pen(brush.Color), point3.X, point3.Y, point2.X, point2.Y);
        }

        public override void Move(int h1, int h2)
        {
            base.Move(h1, h2);
            point3.X += h1;
            point3.Y += h2;
        }
    }
}
