using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameForSemestr
{
    class GameController
    {
        public static Image spritesheet;
        public static List<Road> roads;
        public static List<Wall> walls;
        public static List<Enemyfly> enemyflies;
        public static int dangerSpawn = 10;
        public static int countDangerSpawn = 0;
        public static void Init()
        {
            roads = new List<Road>();
            walls = new List<Wall>();
            enemyflies = new List<Enemyfly>();

            spritesheet = Properties.Resources.Level1;
            GenerateRoad();
        }

        public static void MoveMap()
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].transform.position.X -= 4;
                if (roads[i].transform.position.X + roads[i].transform.size.Width < 0)
                {
                    roads.RemoveAt(i);
                    GetNewRoad();
                }
                
            }
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].transform.position.X -= 4;
                if (walls[i].transform.position.X + walls[i].transform.size.Width < 0)
                {
                    walls.RemoveAt(i);
                }
            }
            for (int i = 0; i < enemyflies.Count; i++)
            {
                enemyflies[i].transform.position.X -= 4;
                if (enemyflies[i].transform.position.X + enemyflies[i].transform.size.Width < 0)
                {
                    enemyflies.RemoveAt(i);
                }
            }
        }

        public static void GetNewRoad()
        {
            Road road = new Road(new PointF(100 * 9, 200), new Size(100, 17));
            roads.Add(road);
            countDangerSpawn++;
            if (countDangerSpawn >= dangerSpawn)
            {
                Random r = new Random();
                dangerSpawn = r.Next(5, 9);
                countDangerSpawn = 0;
                int obj = r.Next(0, 2);
                switch (obj)
                {
                    case 0:
                        Wall cactus = new Wall(new PointF(0 + 100 * 9, 150), new Size(50, 50));
                        walls.Add(cactus);
                        break;
                    case 1:
                        Enemyfly bird = new Enemyfly(new PointF(0 + 100 * 9, 110), new Size(50, 50));
                        enemyflies.Add(bird);
                        break;
                }
            }
        }
        public static void GenerateRoad()
        {
            for (int i = 0; i < 10; i++)
            {
                Road road = new Road(new PointF(0 + 100 * i, 200), new Size(100, 17));
                roads.Add(road);
                countDangerSpawn++;
            }
            
        }

        public static void DrawObjets(Graphics g)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].DrawSprite(g);
            }
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].DrawSprite(g);
            }
            for (int i = 0; i < enemyflies.Count; i++)
            {
                enemyflies[i].DrawSprite(g);
            }
        }
    }
}
