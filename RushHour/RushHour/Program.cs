﻿using System;
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
            Car c = new Car(3, 4, Vehicle.Direction.HORIZONTAL);
            RedCar rc = new RedCar(5, 2, Vehicle.Direction.VERTICAL);
            Truck t = new Truck(0, 1, Vehicle.Direction.VERTICAL);

            RushHourBoard board = new RushHourBoard();
            board.add(c);
            board.add(rc);
            board.add(t);
            Console.WriteLine(board.moveDown(t));
            board.printBoard();

            board.move(c, 1);
            board.printBoard();
        }
    }
}
