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
        int goalXposition;
        int goalYposition;

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
        public void setGoal(int x, int y){
        
            goalXposition=x;
            goalYposition = y;
            // the goal is represented by a @.
            goal = '@';
            // check if the goal location is free
            if (board[goalXposition, goalXposition] == null)
            {
                board[goalXposition,goalYposition] = goal;
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
                {
                    Console.Write(".");
                }
                for (int j = 0; j < colLength; j++)
                {
                    // WORKS
                    while (board[i, j] == null)
                    {
                        board[i, j] = '.';
                    }
                    // DOESN'T WORK YET
                    //while (board[i, j] != null)
                    //{
                    //    board[i, j] = Vehicle.vehicle_name;
                    //}
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }

        //Get the board (including vehicles) as a string.
        //This is used for comparing two boards.
        public string GetBoardString()
        {
            //May replace this list with an array in the future.
            List<char> boardCharList = new List<char>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //Add character for empty slot.
                    boardCharList.Add('*');

                    if (board[i, j] is Car)
                    {
                        ////Add name to the board.
                        //Car tempCar = (Car)board[i,j];
                        //boardCharList.Add(tempCar.getName());
                        //tempCar = null;

                        //If slot is Car, then remove added * and add Car sign (c).
                        boardCharList.RemoveAt(boardCharList.Count - 1);
                        boardCharList.Add('c');

                    }
                    if (board[i, j] is Truck)
                    {
                        //If slot is Truck, then remove added * and add Truck sign (t).
                        boardCharList.RemoveAt(boardCharList.Count - 1);
                        boardCharList.Add('t');

                    }
                    if (board[i, j] is RedCar)
                    {
                        //If slot is RedCar, then remove added * and add RedCar sign (t).
                        boardCharList.RemoveAt(boardCharList.Count - 1);
                        boardCharList.Add('r');

                    }
                }
            }
            return boardCharList.ToString();
        }
    }
}
