using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Figure
    {
        protected List<Point> plist;

        public void Draw()
        {
            foreach (Point p in plist)
            {
                p.Draw();
            }
        }
        internal bool IsHit(Figure figure)
        {
            foreach (var p in plist)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point)
        {
            foreach (var p in plist)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}