using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etwas_richtig_cooles
{
    class Class1
    {
        private int x=0, y=0;
        private int laenge=0;
        
        public Class1(int cX, int cY)
        {
            x = cX;
            y = cY;
        }
        public Class1()
        {

        }
        ~Class1()
        {}
        public void setLaenge(int sL)
        {
            laenge = sL;
        }
        public int getLaenge()
        {
            return laenge;
        }

        public void setY(int sY)
        {
            y = sY;
        }

        public int getY()
        {
            return y;
        }
        public int getX()
        {
            return x;
        }
        public void setX(int sX)
        {
            x = sX;
        }
    }
}
