using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InheritApp
{
    public partial class Form1 : Form
    {
        List<Figure> fList;
        Circle L1;
        int x1, y1; // first Click
        //int x2, y2; // second Click
        Figure selFugure;

        enum modes { DRAW, SELECT, DELETE, Color }
        modes mode;

        public Form1()
        {
            InitializeComponent();
            fList = new List<Figure>();
            x1 = y1 = 0;
            mode = modes.DRAW;
            selFugure = null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            mode = modes.SELECT;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            mode = modes.DRAW;
        }
        private void ToolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.BackColor = Color.Red;
            toolStripMenuItem2.BackColor = Color.Black;
            toolStripMenuItem3.BackColor = Color.Yellow;
            toolStripMenuItem4.BackColor = Color.Green;
           

        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            foreach(Figure f in fList)
            {
                f.Draw(g);
            }
        }

        private void Form1_MouseClick(object sender,
            MouseEventArgs e)
        {
            switch (mode)
            {
                case modes.DRAW:
                    if (x1 == 0 && y1 == 0) // First Click !!
                    {
                        x1 = e.X; y1 = e.Y;
                    }
                    else // Second Click
                    {
                        // Create a Figure
                        //L1 = new Line(x1, y1, e.X, e.Y);
                        L1 = new Circle(x1, y1, e.X, e.Y, Color.Blue);
                        // Add to List
                        fList.Add(L1);
                        // Redraw
                        this.Invalidate();
                        x1 = y1 = 0;
                    }
                    break;

                case modes.SELECT:
                    if (selFugure != null)
                        selFugure.Select(false);

                    selFugure = FindFigure(e.X, e.Y);
                    if (selFugure != null)
                    {
                        selFugure.Select(true);
                        this.Invalidate();
                    }
                    break;
                case modes.Color:

                    break;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            mode = modes.DELETE;
            if(selFugure != null)
            {
                fList.Remove(selFugure);
                Invalidate();
                selFugure = null;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripDropDownButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            selFugure.setColor(Color.Green);
            this.Invalidate();
        }

        private void toolStripDropDownButton2_Click_2(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            selFugure.setColor(Color.Red);
            this.Invalidate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            selFugure.setColor(Color.Black);
            this.Invalidate();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            selFugure.setColor(Color.Yellow);
            this.Invalidate();
        }

        private Figure FindFigure(int x, int y)
        {
            for(int i=0; i<fList.Count; i++)
            {
                if (fList[i].isInside(x, y))
                    return fList[i];
            }
            return null;
        }
    }
}
