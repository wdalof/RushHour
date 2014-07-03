using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Car : Vehicle
    {
        public static int length = 2;


        //public Car(int x, int y, Vehicle.Direction direction)
        //    : base(x, y, length, direction)
        //{
        //}

        public Car(int x, int y, Vehicle.Direction direction, char c)
            : base(x, y, length, direction, c)
        {
        }

    }


}