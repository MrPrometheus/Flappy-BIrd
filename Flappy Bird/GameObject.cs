using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    class GameObject : PictureBox
    {
        

        public GameObject()
        {
            GameForm.collectionOfGameObjects.Add(this);
        }
        public virtual void UpdateGameObject() { }

        public static void UpdateAllObjects()
        {
            foreach(GameObject obj in GameForm.collectionOfGameObjects)
            {
                obj.UpdateGameObject();
            }
        }

        public bool CollidedWith(GameObject other)
        {
            if(this != other)
            {
                if (this.Bounds.IntersectsWith(other.Bounds))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
             
        }
    }
}
