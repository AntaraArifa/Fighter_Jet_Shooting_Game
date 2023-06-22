using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fighter_Jet_Shooting_Game
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, shooting, isGameOver;
        int playerspeed = 15;
        int enemyspeed = 5;
        int bulletSpeed = 0;
        int score = 0;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void maingametimerevent(object sender, EventArgs e)
        {

            txtScore.Text = score.ToString();

            enemy1.Top += enemyspeed;
            enemy2.Top += enemyspeed;
            enemy3.Top += enemyspeed;


            if (enemy1.Top > 510 || enemy2.Top > 510 || enemy3.Top > 510)
            {
                gameOver();
            }


            if (goLeft == true && fighter.Left > 0)
            {
                fighter.Left -= playerspeed;
            }
            if (goRight == true && fighter.Left < 600)
            {
                fighter.Left += playerspeed;
            }
            if(shooting == true)
            {
                bulletSpeed = 25;
                bullet.Top -= bulletSpeed;
            }
            else
            {
                bullet.Left = -300;
                bulletSpeed = 0;
            }
           if(bullet.Top < -30)
            {
                shooting = false;
            }

           if(bullet.Bounds.IntersectsWith(enemy1.Bounds))
            {
                score += 1;
                enemy1.Top = -400;
                enemy1.Left = rnd.Next(20, 600);
                shooting = false;
            }

            if (bullet.Bounds.IntersectsWith(enemy2.Bounds))
            {
                score += 1;
                enemy2.Top = -650;
                enemy2.Left = rnd.Next(20, 600);
                shooting = false;
            }

            if (bullet.Bounds.IntersectsWith(enemy3.Bounds))
            {
                score += 1;
                enemy3.Top = -500;
                enemy3.Left = rnd.Next(20, 600);
                shooting = false;
            }
            if(score == 10)
            {
                enemyspeed = 7;
            }
            if (score == 15)
            {
                enemyspeed = 9;
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;

                bullet.Top = fighter.Top - 30;
                bullet.Left = fighter.Left + 30;

            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            gameTimer.Start();

            enemy1.Left = rnd.Next(20, 600);
            enemy2.Left = rnd.Next(20, 600);
            enemy3.Left = rnd.Next(20, 600);

            enemy1.Top= rnd.Next(0, 200) * -1;
            enemy2.Top = rnd.Next(0, 450) * -1;
            enemy3.Top = rnd.Next(0, 700) * -1;

            bullet.Left = -300;
            shooting = false;

            txtScore.Text = score.ToString();

        }

        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text += Environment.NewLine + "Game Over !!" + Environment.NewLine + "Press Enter to try again!";
            score = 0;
        }
    }
}
