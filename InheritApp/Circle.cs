using System;
 using System.Drawing; 

namespace InheritApp
{
    class Circle:Figure
    {
        // Second line poin 
        int x2, y2;

        public Circle(int x, int y) :
            base(x, y)
        {
            x2 = y2 = 0;
        }

        public Circle(int x, int y, int x2, int y2, Color c) :
            base(x, y, c)
        {
            this.x2 = x2;
            this.y2 = y2;
        }

        internal override void Draw(Graphics g)
        {
            Pen pen;
            if (selected)
                pen = new Pen(color, 3);
            else
                pen = new Pen(color);

            g.DrawEllipse(pen, x, y, x2, x2);
        }

        internal override bool isInside(int xm, int ym)
        {
            double dist1 = Distance(xm, ym, x , y);
            double dist2 = Distance(xm, ym, x2, y2);
            double len = Distance(x, y, x2, y2);
            if (Math.Abs(dist1 + dist2 - len) < x2)
                return true;
            else
                return false;
        }

        private double Distance(int xm, int ym, int x, int y)
        {
            int dx = xm - x;
            int dy = ym - y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

    }
}
