using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForSemestr
{
    public partial class Form2 : Form
    {



        Player player;
        Timer mainTimer;
        static Stream str = Properties.Resources.Contra_SFX__15_;
        static Stream str1 = Properties.Resources.Contra_SFX__14_;

        SoundPlayer snd = new SoundPlayer(str);
        SoundPlayer snd1 = new SoundPlayer(str1);


        Ball ball;
        SolidBrush brush = new SolidBrush(Color.Red);
        Pen pen = new Pen(Brushes.Red);
        Bitmap image = new Bitmap("giphy.gif");
        Bitmap image1 = new Bitmap("giphy1.gif");
        Bitmap bitmap = new Bitmap("Title.png");
        public bool move = false;



        Random r = new Random();
        public Form2()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Width = 700;
            this.Height = 300;

            this.Paint += new PaintEventHandler(DrawGame);

            this.KeyDown += new KeyEventHandler(OnKeyboardDown);
            mainTimer = new Timer();
            mainTimer.Interval = 10;
            mainTimer.Tick += new EventHandler(Update);

            axWindowsMediaPlayer1.URL = "ab.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();

            snd1.Stop();
            snd.Stop();
            Init();

        }

        private void OnKeyboardDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Up:
                    if (!player.physics.isJumping)
                    {
                        player.physics.AddForce();
                    }
                    break;

                case Keys.Right:
                    if (!move)
                    {
                        player.shoot = true;
                        ball.location = new Point((int)player.physics.transform.position.X, (int)player.physics.transform.position.Y + 20);
                    }
                    break;
                case Keys.Escape:
                    this.Close();
                    Form1 newForm = new Form1();
                    newForm.Show();
                    break;
            }

        }

        public Bitmap SwapImage()
        {

            if (r.Next(0, 2) == 0)
            {
                return image;
            }
            else
            {
                return image1;
            }
        }

        public void Init()
        {
            GameController.Init();
            player = new Player(new PointF(20, 149), new Size(50, 50));
            
            ball = new Ball(new Point(0, -200), new Size(10, 10), pen);
            mainTimer.Start();
            Invalidate();
        }

        public void Update(object sender, EventArgs e)
        {
            player.score++;
            this.Text = "Dino - Score: " + player.score;

            if (player.physics.Collide())
            {
                Init();

            }
            player.physics.ApplyPhysics();

            GameController.MoveMap();


            Invalidate();
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            if (player.score % 1000 == 0)
            {
                bitmap = SwapImage();
            }

            e.Graphics.DrawImage(bitmap, 0, 0, this.Width, this.Height);


            player.DrawSprite(g);
            GameController.DrawObjets(g);
            g.FillEllipse(brush, ball.location.X, ball.location.Y, ball.size.Width, ball.size.Height);
        }

       

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (player.shoot)
            {
                move = true;
            }
            for (int i = 0; i < GameController.enemyflies.Count; i++)
            {
                var bird = GameController.enemyflies[i];
                if (ball.Bounds.IntersectsWith(bird.Bounds))
                {
                    GameController.enemyflies.RemoveAt(i);
                    try { snd.Play(); }
                    catch { }
                    

                    ball.location = new Point(0, -200);
                }

            }
            for (int i = 0; i < GameController.walls.Count; i++)
            {
                var wall = GameController.walls[i];
                if (ball.Bounds.IntersectsWith(wall.Bounds))
                {
                    snd1.Play();
                    ball.location = new Point(0, -200);
                }

            }

            if (ball.location.X < -50 || ball.location.X > ClientSize.Width + 10)
            {
                move = false;
            }
            if (move)
            {

                ball.location.X += 28;

            }
        }
    }
}
