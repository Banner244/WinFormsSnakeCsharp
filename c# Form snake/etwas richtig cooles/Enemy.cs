using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etwas_richtig_cooles
{
    class Enemy
    {
        private int x = 1, y = 1;
        public Enemy(int eX, int eY)
        {
            x = eX;
            y = eY;
        }
        public Enemy()
        {
            
        }
        public void setX(int sX)
        {
            x = sX;
        }
        public void setY(int sY)
        {
            y = sY;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }
}
