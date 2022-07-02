using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForSemestr
{
    class Enemyfly
    {
        public Transform transform;
        int frameCount = 0;
        int animationCount = 0;

        public Enemyfly(PointF pos, Size size)
        {
            transform = new Transform(pos, size);
        }
        public Rectangle Bounds
        {
            get
            {
                return (new Rectangle((int)transform.position.X,(int)transform.position.Y, transform.size.Width, transform.size.Height));
            }
        }
        public void DrawSprite(Graphics g)
        {
            frameCount++;
            if (frameCount <= 10)
                animationCount = 0;
            else if (frameCount > 10 && frameCount <= 20)
                animationCount = 1;
            else if (frameCount > 20)
                frameCount = 0;

            g.DrawImage(Properties.Resources.contra_enemies, new Rectangle(new Point((int)transform.position.X, (int)transform.position.Y), new Size(transform.size.Width, transform.size.Height)),195+ 26 * animationCount, 480, 22, 27-5*animationCount, GraphicsUnit.Pixel);
        }
    }
}
