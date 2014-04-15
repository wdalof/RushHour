using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class RedCar : Car
    {
        public RedCar(int x, int y, Direction dir) : base(x, y, dir, 'r') {}

        public RedCar(int x, int y, Direction dir, char c) : base (x, y, dir, c) {}

    }
}
