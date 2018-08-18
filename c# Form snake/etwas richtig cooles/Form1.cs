using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etwas_richtig_cooles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Class1 player = new Class1();
        Enemy gegner = new Enemy();
        world w = new world(35, 20);//70, 40 standard
        int rX, rY;
        int counter = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            richTextBox1.Enabled = false;
            textBox1.Enabled = false;
            checkBox1.Enabled = false;

            player.setX(2); player.setY(2);
            w.wPlayerPos(player.getX(), player.getY());
            enemyy(1, 1);
            timer1.Start();
            richTextBox1.Text = w.createWorld();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            w.Snake(aX, aY, player.getLaenge());
            textBox1.Text = "x: " + player.getX() + ", y: " + player.getY() + " Counter: " + player.getLaenge()/*+" "+ counter*/;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox1.Checked)
            {
                switch (e.KeyData)
                {
                    case Keys.Right: automove(0); break;
                    case Keys.Left: automove(1); break;
                    case Keys.Up: automove(2); break;
                    case Keys.Down: automove(3); break;
                }
            }
            else
            {
                if (e.KeyData == Keys.Right && player.getX() != w.getLength() - 2)
                {
                    coords();
                    RIGHT();
                    refreshworld();
                }
                else if (e.KeyData == Keys.Left && player.getX() != 1)
                {
                    coords();
                    LEFT();
                    refreshworld();
                }
                else if (e.KeyData == Keys.Up && player.getY() != 1)
                {
                    coords();
                    UP();
                    refreshworld();
                }
                else if (e.KeyData == Keys.Down && player.getY() != w.getWidth() - 2)
                {
                    coords();
                    DOWN();
                    refreshworld();
                }
            }
        }

        void automove(int richtung)
        {
            for (int i = 0; i < move.Length; i++)
            {
                if (richtung == i){
                    move[i] = true;
                }else{
                    move[i] = false;
                }
            }
            timerautomove.Start();
        }
        bool[] move = {false, false, false, false};
        private void timerautomove_Tick(object sender, EventArgs e)
        {
                coords();
                if (move[0] == true)
                {
                    RIGHT();
                }
                else if (move[1] == true)
                {
                    LEFT();
                }
                else if (move[2] == true)
                {
                    UP();
                }
                else if (move[3] == true)
                {
                    DOWN();
                }
                refreshworld();
        }

        void coords ()
        {
            if (counter!=-1)
            {
                aX[counter] = player.getX();
                aY[counter] = player.getY();
            }
            //counter++;
        }
        int[] aX = new int[0];
        int[] aY = new int[0];
        void refreshworld()
        {
            if((player.getX()==gegner.getX())&&(player.getY()==gegner.getY()))
            {
                player.setLaenge(player.getLaenge()+1);


                Array.Resize(ref aX, player.getLaenge());
                Array.Resize(ref aY, player.getLaenge());
                counter++;
                
                Random rdm = new Random();
                rX = rdm.Next(1, w.getLength()-2);
                rY = rdm.Next(1, w.getWidth() - 2);
                enemyy(rX, rY);

           //     enemyy(int x, int y);
            }
            richTextBox1.Text = w.createWorld();
        }

        void enemyy(int x, int y)
        {
            //   gegner.
            gegner.setX(x); gegner.setY(y);
            w.wEnemyPos(x, y);
        }
        //
        void RIGHT()
        {
            w.wPlayerPos(player.getX() + 1, player.getY());
            player.setX(player.getX() + 1);
        }
        void LEFT()
        {
            w.wPlayerPos(player.getX() - 1, player.getY());
            player.setX(player.getX() - 1);
        }
        void UP()
        {
            w.wPlayerPos(player.getX(), player.getY() - 1);
            player.setY(player.getY() - 1);
        }
        void DOWN()
        {
            w.wPlayerPos(player.getX(), player.getY() + 1);
            player.setY(player.getY() + 1);
        }
    }
}
