using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Project2021
{
    public class Rect
    {
        public Brush color { get; set; }
        private Rectangle rect;
        public string text { get; set; } // the text inside the rectangle
        private Font font  = new Font("Arial", 8, FontStyle.Regular);
        public static Graphics gu;
        
        // The constructer
        public Rect( int x , int y, int width, int hieght , Brush b, string s )
        {
            color = b;
            rect = new Rectangle(x, y, width, hieght);
            text = s;
        }
        
        // for for painting the rectangle and writing the text
        public void Paint()
        {
            Pen pen = new Pen(Color.Gray, 3);
            gu.DrawRectangle(pen, rect);
            gu.FillRectangle( color , rect );
            gu.DrawString(text , font, Brushes.Black, rect.X + 2, rect.Y + 2);
        }
       
    }
}
