using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2021
{

    public partial class Form1 : Form
    {
        GameBoard gameboard;
        ResourceBoard resourceboard;
        Playertwo playertwo;
        int counter = 0;
       
       
        public void SetBoard() // to set the board at the begining or after the game ends
        {
            
            gameboard.Start();
            resourceboard.Start();
            player.Text = gameboard.GetNumbers()[0].ToString();
            enemy.Text = gameboard.GetNumbers()[1].ToString();
            empty.Text = gameboard.GetNumbers()[2].ToString();
            ResourcesPlayer1.Text = "0";
            WeaponsPlayer1.Text = "0";
            ResourcesPlayer2.Text = "0";
            WeaponsPlayer2.Text = "0";
            Update_Conquer();
            Update_Attack();
        }
        public Form1()
        {
            InitializeComponent();
            gameboard = new GameBoard(7, 7, panel1.Width, panel1.Height);
            resourceboard = new ResourceBoard(7, panel2.Width, panel2.Height);
            SetBoard();
        }


        void Update_Conquer() // to update the state of the conquer label
        {
            if (int.Parse(ResourcesPlayer1.Text) == 0) Conquer.Text = "OFF";
            else Conquer.Text = (int.Parse(ResourcesPlayer1.Text)/5).ToString();
        }
        void Update_Attack()// to update the state of the attack label
        {
            if (int.Parse(ResourcesPlayer1.Text) == 0 || int.Parse(WeaponsPlayer1.Text)==0 ) Attack.Text = "OFF";
            else Attack.Text = ((Math.Min(int.Parse(ResourcesPlayer1.Text), int.Parse(WeaponsPlayer1.Text)))/ 5).ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gameboard.Paint(e.Graphics);
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            resourceboard.Paint(e.Graphics);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)// to change the game board according to the position of the click and the state of resources and weapons.
        {
            if (int.Parse(ResourcesPlayer1.Text) >= 5 && gameboard.GetColorofRect(e.X , e.Y) == Brushes.White)
            {   // the conquer state
                gameboard.RePaint(e.X, e.Y, Brushes.Red, "Me");
                ResourcesPlayer1.Text = (int.Parse(ResourcesPlayer1.Text) - 5).ToString();
                empty.Text = (int.Parse(empty.Text) - 1).ToString();
                player.Text = (int.Parse(player.Text) + 1).ToString();
            }
            else
            {   // the attack state
                if (int.Parse(ResourcesPlayer1.Text) >= 5 && int.Parse(WeaponsPlayer1.Text) >= 5 && gameboard.GetColorofRect(e.X, e.Y) == Brushes.Blue)
                {
                    gameboard.RePaint(e.X, e.Y, Brushes.Red, "Me");
                    ResourcesPlayer1.Text = (int.Parse(ResourcesPlayer1.Text) - 5).ToString();
                    WeaponsPlayer1.Text = (int.Parse(WeaponsPlayer1.Text) - 5).ToString();
                    enemy.Text = (int.Parse(enemy.Text) - 1).ToString();
                    player.Text = (int.Parse(player.Text) + 1).ToString();
                }
                else
                {
                    // the Let GO state
                    if (gameboard.GetColorofRect(e.X, e.Y) == Brushes.Red)
                    {
                        gameboard.RePaint(e.X, e.Y, Brushes.White, " ");
                        WeaponsPlayer1.Text = (int.Parse(WeaponsPlayer1.Text) + 10).ToString();
                        empty.Text = (int.Parse(empty.Text) + 1).ToString();
                        player.Text = (int.Parse(player.Text) - 1).ToString();
                    }
                    
                }
            }
            List<int> L = new List<int>();// to update the number of the red,blue and white rectangles after the click
            L.Add(int.Parse(player.Text));
            L.Add(int.Parse(enemy.Text));
            L.Add(int.Parse(empty.Text));
            gameboard.SetNumbers(L);
            panel1.Refresh();
            Update_Conquer();
            Update_Attack();
            CheckGame();// to reset the game and declare the result in case the game has ended.

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)// to update the resources and weapons after clicking on the rectangles of the resource board.
        {

            if (counter < 3)
            {
                String clicked_resource = resourceboard.GetTextofRect(e.X);
                if (clicked_resource[0] == 'A')
                {
                    WeaponsPlayer1.Text = (int.Parse(WeaponsPlayer1.Text) + int.Parse(clicked_resource.Substring(1)) ).ToString();
                }
                else if (clicked_resource[0] == 'R')
                {
                    ResourcesPlayer1.Text = (int.Parse(ResourcesPlayer1.Text) + int.Parse(clicked_resource.Substring(1))).ToString();
                }
                else
                {
                    counter--;
                }
                resourceboard.RePaint(e.X, Brushes.White);
                Update_Attack();
                Update_Conquer();
            }
            counter += 1;
            if (counter >= 3)
            {
                button1.Enabled = true;
            }
            panel2.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)// what happened when the "Next Turn" button clicked.
        {
            button1.Enabled = false;
            counter = 0;
            // the player2 turn
            resourceboard.Start();
            playertwo = new Playertwo(gameboard, resourceboard);
            List<int> L = playertwo.PlayTurn( int.Parse(ResourcesPlayer2.Text) , int.Parse(WeaponsPlayer2.Text) );
            ResourcesPlayer2.Text = L[0].ToString();
            WeaponsPlayer2.Text = L[1].ToString();
            empty.Text = L[2].ToString();
            enemy.Text = L[3].ToString();
            player.Text = L[4].ToString();
            resourceboard.Start();
            panel1.Refresh();
            panel2.Refresh();
            CheckGame();
            
        }
        public void CheckGame()// to reset the game and declare the result in case the game has ended.
        {
            if (gameboard.GameEnd() == 1)
            {
                MessageBox.Show("You Won");
                SetBoard(); 
                panel1.Refresh();
                panel2.Refresh();
            }
            else if (gameboard.GameEnd() == 2)
            {
                MessageBox.Show("GAME OVER");
                SetBoard();
                panel1.Refresh();
                panel2.Refresh();
            }
           
        }

    }
}
