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
        Object[,] board;
        List<Vehicle> vehicles =new List<Vehicle>();
        Object goal;
        string clashErrorMessage = "Vehicle clash";

        public RushHourBoard()
        {
            width = size;
            height = size;
            initBoard();
        }

        public void initBoard()
        {
            board = new Object[size, size];

            //set all x and y values to null 
            for (int k = 0; k < board.GetLength(0); k++)
                for (int l = 0; l < board.GetLength(1); l++)
                    board[k, l] = null;
            //set the goal
            this.setGoal(1,2);
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
                        throw new CustomException(clashErrorMessage);

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
                        throw new CustomException(clashErrorMessage);
                }
            }
        }
        // set the goal to a specified x / y location on the board
        public void setGoal(int x, int y)
        {
            // the goal is represented by a @.
            goal = '@';
            // check if the goal location is free
            if (board[x, y] == null)
            {
                board[x, y] = goal;
            }
            else
                throw new CustomException("The goal position is already taken");
        }

        // get the goal object 
        public Object getGoal()
        {
            return goal;
        }

        //print rushhour board method as a 6 x 6 matrix
        public void printBoard()
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }

        //UNTESTED: Get the board (including vehicles) as a string.
        //This is used for comparing two boards.
        //public string GetBoardString()
        //{
        //    List<char> boardCharList = new List<char>();

        //    for (int i = 0; i < board.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < board.GetLength(1); j++)
        //        {
        //            boardCharList.Add('*');

        //            for (int k = 0; k < vehicles.Count; k++)
        //            {
        //                if (board[i, j].getX() == vehicles[k].getX() || board[i, j].getY() == vehicles[k].getY())
        //                {
        //                    boardCharList.RemoveAt(boardCharList.Count - 1);
        //                    boardCharList.Add(vehicles[k].getName());
        //                }
        //            }
        //        }
        //    }

        //    return boardCharList.ToString();
        //}
    }
}
