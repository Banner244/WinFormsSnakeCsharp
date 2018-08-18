using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etwas_richtig_cooles
{
    class world
    {
        private int x=0, y=0;
        private int wLength;
        private int wWidth;
        private int eX, eY;
        public world(int wL, int wW)
        {
            wLength = wL;
            wWidth = wW;
        }
        public void wPlayerPos(int pX, int pY)
        {
            x = pX;
            y = pY;
        }
        public void wEnemyPos(int pX, int pY)
        {
            eX = pX;
            eY = pY;
        }

        string[,] sSnake = new string[5, 5];
        int[] sX= new int[0];
        int[] sY = new int[0];
        int slaenge;
        public void Snake(int[] sX2, int[] sY2, int laenge)
        {
            Array.Resize(ref sX, sX2.Length);
            Array.Resize(ref sY, sY2.Length);
            sX = sX2;
            sY = sY2;
            slaenge = laenge;
        }
        public world()
        {
            wLength = 5; wWidth = 5;
        }
        
        public string createWorld()
        {
            string[,] aWorld = new string[wLength, wWidth];
            int z=0;
            string cWorld=null;
            if ((x < 1) || (y < 1))
            {
                return "ERROR404(min. x=1, y=1)";
            }
            for (int i =0;i<wLength;i++)
            {
                if((z==0)||(z == wWidth - 1)||(i==0)||(i==wLength-1))//collision start
                {
                    aWorld[i, z] = "x";
                }//collision end
                else if(((i==x)&&( z==y))) //set Playerpos
                {
                    aWorld[i, z] = "o";
                }//Playerpos end
                else if (((i == eX )&& (z ==eY))) //set enemypos
                {
                    aWorld[i, z] = "t";

                }//enemypos end
                else // word object
                {
                    aWorld[i, z] = "  ";
                } // word object end

                int r = -1;
                while (r < sX.Length - 1)
                {
                   r++;
                    if (x == sX[r] && y == sY[r])
                    {
                        return "Game Over";
                    }
                }
                if (slaenge!=0)
                {
                    int k = -1;
                    while (k < sX.Length-1)
                    {
                        k++;       
                        if (i == sX[k] && z == sY[k])
                        {
                            aWorld[sX[k], sY[k]] = "h";
                            if (k != sX.Length - 1)
                            {
                                
                                sX[k] = sX[k + 1];
                                sY[k] = sY[k + 1];
                                //     aWorld[sX[k], sY[k]] = "h";
                            }
                        }
                    }   
                }
                cWorld += aWorld[i, z];
                if (i == wLength-1)
                {
                    if(z!=wWidth-1)
                    {
                        cWorld += "\n";
                        i = -1;
                        z++;
                    }
                    else
                    {
                        break;
                    } 
                }
            }
            return cWorld;
        }

        //get&set
        public int getLength()
        {
            return wLength;
        }
        public void setLength(int lenght)
        {
            wLength = lenght;
        }
        public int getWidth()
        {
            return wWidth;
        }
        public void setWidth(int width)
        {
            wWidth = width;
        }
    }
}
