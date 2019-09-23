using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    class Ground : GameObject
    {
        private const int GROUND_WIDTH = 900;
        private const int GROUND_HEIGHT = 140;
        public Ground()
        {
            InitGraphics();
            InitLocation();
        }

        private void InitGraphics()
        {
            this.Image = Flappy_Bird.Properties.Resources.ground;

            this.Size = new Size(GROUND_WIDTH, GROUND_HEIGHT);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void InitLocation()
        {
            this.Left = 0;
            this.Top = GameForm.SCREEN_CENTER_Y * 2 - GROUND_HEIGHT;
        }
    }
}
