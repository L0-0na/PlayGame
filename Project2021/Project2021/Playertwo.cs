using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2021
{
    public class Playertwo
    {
        public GameBoard gameboard { get; } 
        public ResourceBoard resourceboard { get; }
        
       //the constructer
        public Playertwo ( GameBoard g  , ResourceBoard r)
        {
            gameboard = g;
            resourceboard = r;
        }
        public List<int> PlayTurn(int resources, int weapons)// the gameplay strategy of the second player
        {
            int white = gameboard.GetNumbers()[2];
            int blue = gameboard.GetNumbers()[1];
            int red = gameboard.GetNumbers()[0];
            for (int i = 0; i < 3; i++) // the Strategy for obtaining resources and weapons 
            {

                // If there are white rectangles then priority is given to resources
                if (white > 0) {
                    int res = resourceboard.GetMaxResource();
                    if (res != -1)// if the are no more resources rectangles, we take weapons rectangles.
                    {
                        resources += res;
                    }
                    else
                    {
                        weapons += resourceboard.GetMaxWeapon();
                    }
                }
                else // if there are no more white rectangles, we want the resources and weapons to be equal to make attack.
                {
                    if (resources - weapons > 0)
                    {
                        int wep = resourceboard.GetMaxWeapon();
                        if (wep != -1)// if the are no more weapons rectangles, we take resources rectangles
                        {
                            weapons += wep;
                        }
                        else
                        {
                            resources += resourceboard.GetMaxResource();
                        }
                    }
                    else
                    {
                        int res = resourceboard.GetMaxResource();
                        if (res != -1)// if the are no more resources rectangles, we take weapons rectangles
                        {
                            resources += res;
                        }
                        else
                        {
                            weapons += resourceboard.GetMaxWeapon();
                        }
                    }
                }

            }

            while (resources != 0 && gameboard.GameEnd() == 0)// the seconf player will play until he has no resources or the geme ends
            {
                if (white > 0)// if there are white rectabgles we will conquer.
                { 
                    gameboard.ConquerEnemy();
                    resources -= 5;
                    blue++;
                    white--;

                }
                else// if there are no more white rectabgles we will attack.
                {
                    if (weapons >= 5)
                    {
                        gameboard.AttackEnemy();
                        resources -= 5;
                        weapons -= 5;
                        blue++;
                        red--;
                    }
                    else // if we don't have enough weapons to attak we will let go of a rectangle to get weapons in return.
                    {
                        gameboard.EnemyLetGo();
                        gameboard.AttackEnemy();
                        weapons += 5;
                        resources -= 5;
                        red--;
                        white++;
                    }  
                }
            }
          //updating the number of red, white and blue rectangles and the status of the resources and weapons.
            List<int> L = new List<int>();
            L.Add(resources);
            L.Add(weapons);
            L.Add(white);
            L.Add(blue);
            L.Add(red);
            L.Add(gameboard.GameEnd());
            return L;
        }
    }
}
