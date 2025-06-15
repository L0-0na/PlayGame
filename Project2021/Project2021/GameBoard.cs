using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2021
{
    // the constructer
    public class GameBoard
    {
        protected Rect[,] play_field; // the game board
        protected int sizeX, sizeY , Width , Height; // sizeX,sizeY the number of rectangles in each row and column. Wigth,Height the dimensions of the rectangle.
        protected Random rand = new Random();// for choosing the state of each rectangle
        protected int state;
        private String[] Text = new string[] { "Me", "Him", " "};
        private Brush[] Text_colors = new Brush[] {  Brushes.Red, Brushes.Blue , Brushes.White};
        private List<int> Numbers = new List<int>() { 0, 0, 0 };// the numbers of the red,white and blue rectangles.
        public GameBoard(int x , int y ,  int panelX, int panelY)// x,y the number of rectangles in each row and column. panelX,panelY the dimensions of the game board panel.
        {
            sizeX = x;
            sizeY = y;
            Width = panelX / sizeX;
            Height = panelY / sizeY;
            play_field = new Rect[x,y];
            
        }
       
        // to give random states to each rectangle in the game board.
        public void Start() 
        {
            for (int i = 0; i < Text.Length; i++) Numbers[i] = 0;
            int n = Text.Length;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    state = rand.Next(0, n);
                    play_field[i,j] = new Rect(i * Width, j * Height, Width, Height ,  Text_colors[state] , Text[state]);
                    Numbers[state]++;
                }
            }

        }
     
        public Brush GetColorofRect(int x, int y)// to get the color of rectangle in the position (x,y).
        {
            return play_field[x/Width,y/Height].color ;
        }
        public void Paint(Graphics g) //to paint the game board after setting the random states to each rectangle
        {
            Rect.gu = g;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    play_field[i,j].Paint();
                }
            }
        }
        public void RePaint(int x , int y, Brush b, string txt)// to repaint and change the status of the rectangle in the poistion (x,y).
        {
            int posx = x / Width;
            int posy = y / Height;

            play_field[posx,posy].color = b;
            play_field[posx,posy].text = txt;
        }
       

        public List<int> GetNumbers() // to get the numbers of the blue,red and white rectangles.
        {
            return Numbers;
        }
        public void SetNumbers(List<int> L) // to change the numbers of the blue,red and white rectangles.
        {
             Numbers = L;
        }
        public int GameEnd() // to tell us if the game has ended
        {
            if(Numbers[0] == sizeX*sizeY ) // if the red won.
            {
                return 1;
            }
            else if(Numbers[1] == sizeX * sizeY)// if the blue won
            {
                return 2;
            }
            else // if the game didn't end
            {
                return 0;
            }
        }
        public void AttackEnemy() // to take a rectangle from the enemy
        {
            int x = 0, y = 0;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if(play_field[i, j].text == Text[0])
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }
            Numbers[0]--;
            Numbers[1]++;
            RePaint(x * Width, y * Height, Text_colors[1], Text[1]);
         }
        public void ConquerEnemy() // to take an empty (white) rectangle
        {
            int x = 0, y = 0;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (play_field[i, j].text == Text[2])
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }
            Numbers[2]--;
            Numbers[1]++;
            RePaint(x*Width, y*Height, Text_colors[1], Text[1]);
        }

        public void EnemyLetGo() // To give up the rectangle in exchange for weapons
        {
            int x = 0, y = 0;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (play_field[i, j].text == Text[1])
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }
            Numbers[1]--;
            Numbers[2]++;
            RePaint(x * Width, y * Height, Text_colors[2], Text[2]);
        }
    }
}
