using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    class Pipe : GameObject
    {
        public const int PIPE_WIDTH = 100;
        public const int PIPE_HEIGHT = 300;
        public enum VerticalDirection
        {
            Up, Down
        }
        private VerticalDirection Direction { get; set; }

        public Pipe(VerticalDirection dir)
        {
            Direction = dir;
            GameForm.collectionOfPipes.Add(this);
            InitGraphics();         
        }

        private void InitGraphics()
        {
            if (Direction == VerticalDirection.Up)
            {
                this.Image = Flappy_Bird.Properties.Resources.pipe;
                
            } else if(Direction == VerticalDirection.Down)
            {
                this.Image = Flappy_Bird.Properties.Resources.pipedown;
            }
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Size = new Size(PIPE_WIDTH, PIPE_HEIGHT);
        }
    }
}
