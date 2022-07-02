using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameForSemestr
{
    class Physics
    {
        public Transform transform;
        float gravity;
        float a;
        public bool isShoot;
        public bool isJumping;
        

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            a = 0.5f;
            isJumping = false;
            isShoot = false;
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }

        public void CalculatePhysics()
        {
            if (transform.position.Y < 150 || isJumping)
            {
                transform.position.Y += gravity;
                gravity += a;
            }
            if (transform.position.Y > 150)
                isJumping = false;
        }
        public bool Collide()
        {
            for (int i = 0; i < GameController.walls.Count; i++)
            {
                var cactus = GameController.walls[i];
                PointF delta = new PointF();
                delta.X = (transform.position.X + transform.size.Width / 2) - (cactus.transform.position.X + cactus.transform.size.Width / 2);
                delta.Y = (transform.position.Y + transform.size.Height / 2) - (cactus.transform.position.Y + cactus.transform.size.Height / 2);
                if (Math.Abs(delta.X) <= transform.size.Width / 2 + cactus.transform.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= transform.size.Height / 2 + cactus.transform.size.Height / 2)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < GameController.enemyflies.Count; i++)
            {
                var bird = GameController.enemyflies[i];
                PointF delta = new PointF();
                delta.X = (transform.position.X + transform.size.Width / 2) - (bird.transform.position.X + bird.transform.size.Width / 2);
                delta.Y = (transform.position.Y + transform.size.Height / 2) - (bird.transform.position.Y + bird.transform.size.Height / 2);
                if (Math.Abs(delta.X) <= transform.size.Width / 2 + bird.transform.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= transform.size.Height / 2 + bird.transform.size.Height / 2)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }

        
        public void AddForce()
        {
            if (!isJumping)
            {
                isJumping = true;
                gravity = -12;
            }
        }

        
    }
}
