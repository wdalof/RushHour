using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    public abstract class Vehicle
    {
        public static char vehicle_name = 'a';

        private int x;
        private int y;
        private int length;
        private Direction direction;
        protected char name;


        public enum Direction
        {
            HORIZONTAL, VERTICAL
        }
        //constructor
        public Vehicle(int x, int y, int length, Direction dir)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.direction = dir;
            this.name = vehicle_name++;
        }
        // constructor
        public Vehicle(int x, int y, int length, Direction dir, char c)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.direction = dir;
            this.name = c;
        }


        // get vehicle direction
        public Direction getDirection()
        {
            return direction;
        }
        // get x pos of the vehicle
        public int getX()
        {
            return x;
        }
        // get y pos of the vehicle
        public int getY()
        {
            return y;
        }
        // get length of the vehicle
        public int getLength()
        {
            return length;
        }

        public char getName()
        {
            return name;
        }

      
    }
}

