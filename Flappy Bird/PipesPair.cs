using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Flappy_Bird
{
    class PipesPair : GameObject
    {
        private const int PIPE_MARGIN = 150;
        private const int PIPE_SPEED = 5;


        private Pipe pipeTop = new Pipe(Pipe.VerticalDirection.Down);
        private Pipe pipeBot = new Pipe(Pipe.VerticalDirection.Up);

        private int horizontalPosition = 0;
        

        internal Pipe PipeTop { get => pipeTop; }
        internal Pipe PipeBot { get => pipeBot; }
        public int HorizontalPosition { get => horizontalPosition; }

        public PipesPair()
        {
            SpawnPipes();          
        }

        private void RandomVerticalPosition()
        {
            Random rand = new Random();
            int offsetFromCenter = rand.Next(-50, 100);

            pipeBot.Top = GameForm.SCREEN_CENTER_Y + offsetFromCenter;
            pipeTop.Top = pipeBot.Top - PIPE_MARGIN - Pipe.PIPE_HEIGHT;
        }

        private void SpawnPipes()
        {
            RandomVerticalPosition();

            pipeBot.Left = horizontalPosition;
            pipeTop.Left = horizontalPosition;
        }

        public void SetHorizontalPosition(int pos)
        {
            horizontalPosition = pos;
            pipeTop.Left = pos;
            pipeBot.Left = pos;
        }

        public override void UpdateGameObject()
        {
            horizontalPosition = pipeTop.Left;
            pipeBot.Left -= PIPE_SPEED;
            pipeTop.Left -= PIPE_SPEED;

            if (pipeTop.Left < -100)
            {
                RandomVerticalPosition();
                pipeBot.Left = GameForm.SCREEN_WEIGHT;
                pipeTop.Left = GameForm.SCREEN_WEIGHT;
            }
        }

    }
}

