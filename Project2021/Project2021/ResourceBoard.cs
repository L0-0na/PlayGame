using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2021
{
    public class ResourceBoard : GameBoard
    {
        private String [] R_W = new string[] { "R5", "R10", "R30", "A20" };
        private Brush[] colors = new Brush[] { Brushes.LightGreen, Brushes.LightBlue, Brushes.Gold, Brushes.MistyRose };
       
        //the constructer based on the Gameboard contructer
        public ResourceBoard(int x , int panelX , int panelY ) : base(x ,1 , panelX , panelY)
        {
        }
       
        // the overrided "start" method to set the resource board randomly 
        public new void Start()
        {
            int n = R_W.Length;
            for (int i = 0; i < sizeX; i++)
            {
                state = rand.Next(0, n );
                play_field[i,0] = new Rect(i * Width, 0, Width , Height , colors[state] , R_W[state]);
            }
        
        }
       
        // to change the state of a resourse board in position x into empty rectangle after clicking on it.
        public void RePaint(int x, Brush b)
        {
            base.RePaint(x, 0, b, " ");
        }
       
        // to get the text inside a resource rectangle in the position x.
        public string GetTextofRect(int x )
        {
            return play_field[x/Width,0].text;
        }

      // to get the max number of avaliable resources
        public int GetMaxResource( )
        {
            int maxx = -1;
            int index = 0;
            for (int i = 0; i < sizeX; i++)
            {
                if (play_field[i, 0].text[0] == 'R' && int.Parse(play_field[i, 0].text.Substring(1)) > maxx)
                {
                    index = i;
                    maxx = int.Parse(play_field[i, 0].text.Substring(1));
                }
            }
            if( maxx != -1)
                RePaint(index * Width, Brushes.White);
            return maxx;
        }

        // to get the max number of avaliable weapons
        public int GetMaxWeapon()
        {
            int maxx = -1;
            int index = 0;
            for (int i = 0; i < sizeX; i++)
            {
                if (play_field[i, 0].text[0] == 'A' && int.Parse(play_field[i, 0].text.Substring(1)) > maxx)
                {
                    index = i;
                    maxx = int.Parse(play_field[i, 0].text.Substring(1));
                }
            }
            if (maxx != -1)
                RePaint(index, Brushes.White);
            return maxx;
        }
   
    }
}
