using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Car
    {
        int length;
        int x;
        int y;
        Direction direction;

        public enum Direction
        {
            HORIZONTAL,VERTICAL
        }

        public Car(int x,int y,int length, Car.Direction direction)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.direction = direction;
        }

        public Direction getDirection()
        {
            return direction;
        }

        public int getX()
        {
            return x;
        }
    }

   
}
