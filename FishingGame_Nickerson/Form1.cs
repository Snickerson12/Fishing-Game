using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FishingGame_Nickerson
{
    public partial class Form1 : Form
    {
        private int boatMoves = 0;
        private int fishcount = 0;
        PictureBox[] Fish;

        public Form1()
        {
            InitializeComponent();
            Fish = new PictureBox[] { Fish1, Fish2, Fish3, Fish4, Fish5, Fish6, Fish7, Fish8, Fish9, Fish10 };
            foreach (PictureBox f in Fish) 
            { 
                f.Visible = true;
            }
            foreach (PictureBox location in Fish)
            {
                Random top = new Random();
                int test = top.Next(0, 430);
                location.Top = test;
                Thread.Sleep(1);

                int test2 = top.Next(0, 400);
                location.Left = test2;
                Thread.Sleep(1);
            }
            
        }
        private void MoveBoat(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    IncrementMoveCount();
                    if(Boat.Left < 554)
                    {
                        Boat.Left += 10;
                    }
                    break;

                case Keys.Left:
                    IncrementMoveCount();
                    if(Boat.Left > 0)
                    {
                        Boat.Left += -10;
                    }
                    break;

                case Keys.Down:
                    IncrementMoveCount();
                    if(Boat.Top < 556)
                    {
                        Boat.Top += 10;
                    } 
                    break;

                case Keys.Up:
                    IncrementMoveCount();
                    if(Boat.Top > 0)
                    {
                        Boat.Top += -10;
                    }
                    break;            
            }
 
            for (int i = 0; i < Fish.Length; i++)
            {
                if (Caughtfish(Fish[i]))
                {
                    IncrementFishCount();
                    Fish[i].Visible = false;
                }
            }    
        }

        private void IncrementMoveCount()
        {
            boatMoves++;
            MoveCountLabel.Text = boatMoves.ToString();
        }

        private void IncrementFishCount()
        {
            fishcount++;
            FishCountLabel.Text = fishcount.ToString();
            if (fishcount == 10)
            {
                MessageBox.Show("10 Fish found! You win!");
            }   
        }
        private bool Caughtfish(PictureBox fish)
        {
            return (Boat.Top <= fish.Top && Boat.Bottom >= fish.Bottom && Boat.Left <= fish.Left && Boat.Right >= fish.Right && fish.Visible == true);
        }
    }
}

