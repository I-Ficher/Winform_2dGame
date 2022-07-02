using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GameForSemestr
{
    class bullet
    {
        //public static List<Point> points;
        //public Transform transform;
        
        Transform transform;
        Pen pen = new Pen(Brushes.Red);
        public bool isShoot;
        float gravity;
        float a;
        public bullet(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            a = 0.5f;
            isShoot = false;
        }

        public void shot()
        {
            
            if (!isShoot)
            {

                isShoot = true;
                //transform.position.X += 100;
                for (int i = 0; i < 50; i++)
                {
                    
                   
                        transform.position.X += 3;
                        
                    

                }
                isShoot = false;
            }
        }
        public void DrawSprite(Graphics g)
        {
            g.DrawEllipse(pen, transform.position.X-1960, transform.position.Y-25, 10, 10);
        }
       
    }
}