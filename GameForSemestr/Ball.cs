using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameForSemestr
{
    class Ball
    {
        public Point location;
        public Size size;
        
        
        Pen pen;
        public Ball(Point location, Size size, Pen pen)
        {
            this.Location = location;
            this.size = size;
            this.pen = pen;
        }
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
        public Rectangle Bounds
        {
            get
            {
                return (new Rectangle(Location.X, location.Y, size.Width, size.Height));
            }
        }
    }
}
