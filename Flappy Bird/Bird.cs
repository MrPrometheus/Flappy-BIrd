using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    class Bird : GameObject
    {
        
        private const int BIRD_WIDTH = 78;
        private const int BIRD_HEIGHT = 62;
        private static readonly Vector2 BIRD_LOCATION = new Vector2(130, 140);
        private bool isJumped;

        private int vspeed = 7;
        private const int MAX_VSPEED = 7;

        public bool IsJumped { get => isJumped; set => isJumped = value; }

        public Bird()
        {
            this.isJumped = false;
            InitGraphics();
            InitLocation();
        }

        private void InitGraphics()
        {
            this.Image = Flappy_Bird.Properties.Resources.bird;

            this.Size = new Size(BIRD_WIDTH, BIRD_HEIGHT);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void InitLocation()
        {
            this.Left = (int)BIRD_LOCATION.X;
            this.Top = (int)BIRD_LOCATION.Y;
        }

        public void Fall()
        {
            if (vspeed > MAX_VSPEED)
            {
                vspeed = MAX_VSPEED;
            }
            else
            {
                vspeed += 1;
            }
        }

        public void ToJump()
        {
            vspeed = -MAX_VSPEED;                 
        }
        
        public override void UpdateGameObject()
        {            
            this.Top += vspeed;
            Fall();
        }  
    }
}
