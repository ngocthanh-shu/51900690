using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class TamGiacDeu : TamGiac
    {
        protected override void Draw2ndLine(Graphics g)
        {
            var distance = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - A.Y, 2));
            var height = distance * Math.Sqrt(3) / 2;

            Point C = new Point(Math.Abs(A.X - B.X) + (int)distance/2, Math.Abs(A.Y - B.Y) + (int)height);
            g.DrawLine(new Pen(Color.Red), A, C);
            g.DrawLine(new Pen(Color.Red), C, B);
        }
    }
}
