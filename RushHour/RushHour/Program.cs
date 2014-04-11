using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car(3, 4, 2, Car.Direction.HORIZONTAL);
            RushHourBoard board = new RushHourBoard();
        }
    }
}
