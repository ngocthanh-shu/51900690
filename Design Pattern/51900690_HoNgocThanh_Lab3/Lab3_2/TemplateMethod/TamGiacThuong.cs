using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class TamGiacThuong : TamGiac
    {
        protected override void Draw2ndLine(Graphics g)
        {
            g.DrawLine(new Pen(Color.Red), A, C);
            g.DrawLine(new Pen(Color.Red), C, B);
        }
    }
}
