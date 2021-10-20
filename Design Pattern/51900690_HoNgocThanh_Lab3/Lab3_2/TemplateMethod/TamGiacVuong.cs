using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class TamGiacVuong : TamGiac
    {
        protected override void Draw2ndLine(Graphics g)
        {
            C = new Point(A.X, B.Y);
            g.DrawLine(new Pen(Color.Red), A, C);
            g.DrawLine(new Pen(Color.Red), C, B);
        }
    }
}
