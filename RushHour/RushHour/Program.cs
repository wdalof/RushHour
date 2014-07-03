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
            Car c = new Car(3, 1, Vehicle.Direction.HORIZONTAL, 'c');
            RedCar rc = new RedCar(3, 2, Vehicle.Direction.VERTICAL);
            Truck t = new Truck(1, 4, Vehicle.Direction.HORIZONTAL, 't');

            RushHourBoard board = new RushHourBoard();
            board.add(c);
            board.add(rc);
            board.add(t);

            Console.WriteLine("Initial board:");
            board.printBoard();

            Console.WriteLine("Press any key to start searching for a solution (using breadth-first search).");
            Console.ReadKey();

            Console.WriteLine();
            BFSearch bfSearch = new BFSearch(board);
            bfSearch.solve();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
