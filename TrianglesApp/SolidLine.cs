using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesApp
{
    internal class SolidLine : SinglePoint
    {
        public SolidLine(SinglePoint point1, SinglePoint point2)
        {
            X = point1.X;
            Y = point1.Y;

            this.point2 = new SinglePoint(point2.X, point2.Y);
            this.brush = point1.brush;
        }

        public SinglePoint point2 { get; set; }

        public virtual void Draw(Graphics g)
        {
            g.DrawLine(new Pen(brush.Color), X, Y, point2.X, point2.Y);
        }

        public override void Move(int h1, int h2)
        {
            base.Move(h1, h2);
            point2.X += h1;
            point2.Y += h2;
        }
    }
}
