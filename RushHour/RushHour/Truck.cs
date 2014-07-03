using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Truck : Vehicle
    {
        public static int length = 3;

        //public Truck(int x, int y, Vehicle.Direction direction)
        //    : base(x, y, length, direction)
        //{
        //}

        public Truck(int x, int y, Vehicle.Direction direction, char c)
            : base(x, y, length, direction, c)
        {
        }

    }
}