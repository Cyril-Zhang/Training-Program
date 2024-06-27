using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ball
    {
        private double size;
        private Color color;
        private int throwCount;

        public Ball(double size, Color color)
        {
            this.size = size;
            this.color = color;
            this.throwCount = 0;
        }

        public void Pop()
        {
            this.size = 0;
        }

        public void Throw()
        {
            if (this.size != 0.0)
            {
                this.throwCount++;
            }
        }

        public int GetThrowCount() { 
            return this.throwCount;
        }

    }
}
