using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    abstract class TamGiac
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        

        public void DrawRec(Graphics g)
        {
            Draw1stLine(g);
            Draw2ndLine(g);
        }

        protected void Draw1stLine(Graphics g)
        {
            g.DrawLine(new Pen(Color.Red), A, B);
        }

        protected abstract void Draw2ndLine(Graphics g);
    }
}
