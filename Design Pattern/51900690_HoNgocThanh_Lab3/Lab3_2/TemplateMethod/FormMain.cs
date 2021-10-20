using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateMethod
{
    public partial class FormMain : Form
    {
        TamGiac a = new TamGiacThuong();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            var tg = new TamGiacDeu();
            tg.A = new Point(100,50);
            tg.B = new Point(150, 80);
            tg.DrawRec(e.Graphics);
        }

        private void FormMain_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            a.A = e.Location;
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            a.A = e.Location;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            a.B = e.Location;
        }
    }
}
