using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class RushHourBoard
    {
        public static int size = 6;
        private int width;
        private int height;
        Vehicle[,] board;
        List<Vehicle> vehicles =new List<Vehicle>();

        public RushHourBoard()
        {
            width = size;
            height = size;
            initBoard();
        }

        public void initBoard()
        {
            board = new Vehicle[size, size];

            //set all x and y values to null 
            for (int k = 0; k < board.GetLength(0); k++)
                for (int l = 0; l < board.GetLength(1); l++)
                    board[k, l] = null;

            this.setGoal(5,2);
        }
        // method for adding a vehicle to the board
        public void add(Vehicle v)
        {
            this.vehicles.Add(v);

            if (v.getDirection() == Vehicle.Direction.HORIZONTAL)
            {
                for (int i = v.getX(); i < (v.getX() + v.getLength()); i++)
                {
                    if (board[i, v.getY()] == null)
                    {
                        board[i, v.getY()] = v;
                    }
                    else
                        Console.WriteLine("Vehicle clash");
                }
            }
            else if (v.getDirection() == Vehicle.Direction.VERTICAL)
            {
                for (int i = v.getY(); i < (v.getY() + v.getLength()); i++)
                {
                    if (board[v.getX(), i] == null)
                    {
                        board[v.getX(), i] = v;
                    }
                    else
                        Console.WriteLine("Vehicle clash");
                }
            }
        }

        public void setGoal(int x, int y)
        {
            Object goal = new Object();
            // the goal is represented by a @.
            board[x, y] = goal;
        }

        //print rushhour board method
        public void printBoard()
        {
            for (int k = 0; k < board.GetLength(0); k++)
                for (int l = 0; l < board.GetLength(1); l++)
                    Console.WriteLine(board[k, l]);
            Console.ReadLine();
        }


    }
}
