using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class TamGiacCan : TamGiac
    {
        protected override void Draw2ndLine(Graphics g)
        {
            Point C = new Point((B.X + A.X)/2,100);
            
            g.DrawLine(new Pen(Color.Red), A, C);
            g.DrawLine(new Pen(Color.Red), C, B);
        }
    }
}
