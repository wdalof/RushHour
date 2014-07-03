using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    public abstract class Vehicle
    {
        //public static char vehicle_name = 'a';
        public static char vehicle_name;

        private int x;
        private int y;
        private int length;
        private Direction direction;
        protected char name;


        public enum Direction
        {
            HORIZONTAL, VERTICAL
        }
        ////constructor
        //public Vehicle(int x, int y, int length, Direction dir)
        //{
        //    this.x = x;
        //    this.y = y;
        //    this.length = length;
        //    this.direction = dir;
        //    this.name = vehicle_name++;
        //}
        // constructor
        public Vehicle(int x, int y, int length, Direction dir, char c)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.direction = dir;
            this.name = c;
        }
        //// vehicle move metod
        //public void move(int length)
        //{
        //    if (direction == Direction.HORIZONTAL)
        //    {
        //        setX(length);
        //    }
        //    else
        //    {
        //        setY(length);
        //    }
        //}

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

        //set the x pos of the vehicle
        public void setX(int x)
        {
            this.x = x;
        }
        // set the y pos of the vehicle
        public void setY(int y)
        {
            this.y = y;
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

