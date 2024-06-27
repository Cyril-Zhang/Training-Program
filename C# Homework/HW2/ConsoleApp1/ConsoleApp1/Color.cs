using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;
        public Color(int red, int green, int blue, int alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = 255;
        }

        public int GetRed()
        {
            return red;
        }

        public int GetGreen()
        {
            return green;
        }

        public int GetBlue()
        {
            return blue;
        }
        public int GetAlpha()
        {
            return alpha;
        }

         public double GetGary()
        {
            return (this.red + this.green + this.blue) / 3;
        }
    }
}
