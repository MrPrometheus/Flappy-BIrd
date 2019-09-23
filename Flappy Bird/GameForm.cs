using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class GameForm : Form
    {
        public static int SCREEN_CENTER_Y;
        public static int SCREEN_WEIGHT;
        public const int FIRST_POSITION_PIPES = 400;
        public const int HORIZONTAL_MARGIN_PIPE = 300;

        public static List<Control> collectionOfGameObjects = new List<Control>();
        public static List<Control> collectionOfPipes = new List<Control>();

        public static int myScore = 0;

        private PipesPair pipes1;
        private PipesPair pipes2;
        private PipesPair pipes3;
        private Bird bird;
        private Ground ground;

        public GameForm()
        {           
            InitializeComponent();
            SCREEN_CENTER_Y = this.Size.Height / 2;
            SCREEN_WEIGHT = this.Size.Width;

            ground = new Ground();
            pipes1 = new PipesPair();
            pipes2 = new PipesPair();
            pipes3 = new PipesPair();
            bird = new Bird();

            this.Controls.Add(ground);
            for(int i=0; i < collectionOfPipes.Count; i++)
            {
                this.Controls.Add(collectionOfPipes[i]);
            }
            this.Controls.Add(bird);

            pipes1.SetHorizontalPosition(FIRST_POSITION_PIPES);
            pipes2.SetHorizontalPosition(FIRST_POSITION_PIPES + HORIZONTAL_MARGIN_PIPE);
            pipes3.SetHorizontalPosition(FIRST_POSITION_PIPES + HORIZONTAL_MARGIN_PIPE * 2);

            endText1.Text = "Game Over!";
            endText2.Text = "Your score: ";
            endText1.Visible = false;
            endText2.Visible = false;
        }

        public void EndGame()
        {
            gameTimer.Stop();
            endText2.Text += myScore;
            scoreText.Visible = false;
            endText1.Visible = true;
            endText2.Visible = true;

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            GameObject.UpdateAllObjects(); 

            for(int i = 0; i < collectionOfGameObjects.Count; i++)
            {
                if (bird.CollidedWith((GameObject)collectionOfGameObjects[i]) || ( bird.Top < -50))
                {
                    EndGame();
                }
            }       

            for(int i = 0; i < collectionOfPipes.Count; i += 2)
            {
                if(bird.Left == collectionOfPipes[i].Left)
                {
                    myScore++;
                    scoreText.Text = myScore.ToString();
                }
            }

            scoreText.Top = bird.Top;
            scoreText.Left = bird.Left + bird.Size.Width;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !bird.IsJumped)
            {
                bird.ToJump();
                bird.IsJumped = true;
            }

        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            bird.IsJumped = false;
        }
    }
}