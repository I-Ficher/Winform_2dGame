using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForSemestr
{
    class Wall
    {
        public Transform transform;
        

        public Wall(PointF pos, Size size)
        {
            transform = new Transform(pos, size);
            
        }

        public Rectangle Bounds
        {
            get
            {
                return (new Rectangle((int)transform.position.X, (int)transform.position.Y, transform.size.Width, transform.size.Height));
            }
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Properties.Resources.contra_enemies, new Rectangle(new Point((int)transform.position.X, (int)transform.position.Y), new Size(transform.size.Width, transform.size.Height)), 38, 510, 20, 30, GraphicsUnit.Pixel);
        }
    }
}
