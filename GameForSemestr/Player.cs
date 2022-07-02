using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameForSemestr
{
    class Player
    {
       
        public Physics physics;
        public int score = 0;
        public bool shoot = false;
        public int framesCount = 0;
        public int animationCount = 0;
        public Player(PointF position, Size size)
        {
            physics = new Physics(position, size);
            framesCount = 0;
            score = 0;

        }

        
        public void DrawSprite(Graphics g)
        {
            
            if (physics.isJumping)
            {
                DrawNeededSprite(g, 118.5f, 44, 16, 39, 37, 0.7f);
            }
            else
            {
                DrawNeededSprite(g, -3.3f,113, 27, 35, 55, 1);
            }
        }

        public void DrawNeededSprite(Graphics g, float srcX, int srcY, int width, int height, int delta, float multiplier)
        {
            framesCount++;
            if (framesCount <= 8)
                animationCount = 0;
            else if (framesCount > 8 && framesCount <= 15)
                animationCount = 1;
            else if (framesCount > 15 && framesCount <= 22)
                animationCount = 2;
            else if (framesCount > 22)
                framesCount = 0;

            g.DrawImage(Properties.Resources.playerBlue, new Rectangle(new Point((int)physics.transform.position.X, (int)physics.transform.position.Y), new Size((int)(physics.transform.size.Width * multiplier), physics.transform.size.Height)), srcX + delta * animationCount/2, srcY, width, height, GraphicsUnit.Pixel);
        }
    }
}
