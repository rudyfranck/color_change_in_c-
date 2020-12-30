using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritApp
{
    abstract class Figure
    {
        protected int x, y; // coordinates of Base Point
        protected Color color; // Outline color
        protected bool selected; // Selection flag

        public Figure(int x, int y)
        {
            this.x = x;
            this.y = y;
            color = Color.Black;
            selected = false;
        }

        public Figure(int x, int y, Color c)
        {
            this.x = x;
            this.y = y;
            this.color = c;
            selected = false;
        }

        public void setColor(Color newColor)
        {
            color = newColor;
        }

        abstract internal void Draw(Graphics g);

        abstract internal bool isInside(int x, int y);
       
        internal void Select(bool value)
        {
            selected = value;
        }
    }
}
