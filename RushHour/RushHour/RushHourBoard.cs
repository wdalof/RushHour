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

        //check if a vehicle can move up
        public bool moveUp(Vehicle v)
        {
            try
            {
                if (board[v.getX(), v.getY() + 1] == null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (IndexOutOfRangeException OutOfRangeException)
            {
                //Console.WriteLine(OutOfRangeException);
                return false;
            }
        }

        // check if  a vehicle can move down
        public bool moveDown(Vehicle v)
        {
            try
            {

                if (board[v.getX(), v.getY() - 1] == null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (IndexOutOfRangeException OutOfRangeException)
            {
                //Console.WriteLine(OutOfRangeException);
                return false;
            }
          
        }

        // check if a vehicle can move left
        public bool moveLeft(Vehicle v)
        {
            try
            {
                if (board[v.getX() - 1, v.getY()] == null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (IndexOutOfRangeException OutOfRangeException)
            {
                //Console.WriteLine(OutOfRangeException);
                return false;
            }

        }

        //check if a vehicle can move right
        public bool moveRight(Vehicle v)
        {
            try
            {
                if (board[v.getX() + 1, v.getY()] == null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (IndexOutOfRangeException OutOfRangeException)
            {
                //Console.WriteLine(OutOfRangeException);
                return false;
            }
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
                    //Check if the object inside is a car/truck or the red car.
                    if ((board[i, j] is Car) || (board[i, j] is Truck) || (board[i, j] is RedCar))
                    {
                        if (board[i, j] is RedCar)
                        {
                            //Create temponary object to get the name.
                            RedCar tempRedCar = (RedCar)board[i, j];
                            //Print the name (on the SAME line, Console.Write vs Console.WriteLine).
                            Console.Write(tempRedCar.getName());
                            //Set object to null for garbage collector.
                            tempRedCar = null;

                            //When printing is done, continue with for loop (skip the if statements below).
                            continue;
                        }
                        if (board[i, j] is Car)
                        {
                            Car tempCar = (Car)board[i, j];
                            Console.Write(tempCar.getName());
                            tempCar = null;

                            continue;
                        }
                        if (board[i, j] is Truck)
                        {
                            Truck tempTruck = (Truck)board[i, j];
                            Console.Write(tempTruck.getName());
                            tempTruck = null;

                            continue;
                        }
                    }
                    else
                    {
                        //When there is no car/truck or red car, print "." (on the same line, Console.Write vs Console.WriteLine).
                        Console.Write(".");
                    }
                }

                //Print a new line when going to next row.
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        //print rushhour board method as a 6 x 6 matrix
        //public void printBoard()
        //{
        //    int rowLength = board.GetLength(0);
        //    int colLength = board.GetLength(1);

        //    for (int i = 0; i < rowLength; i++)
        //    {
        //        {
        //            Console.Write(".");
        //        }
        //        for (int j = 0; j < colLength; j++)
        //        {
        //            // WORKS
        //            while (board[i, j] == null)
        //            {
        //                board[i, j] = '.';
        //            }
        //            // DOESN'T WORK YET
        //            while (board[i, j] != null)
        //            {
        //                board[i, j] = 'c';
        //            }
        //            Console.Write(string.Format("{0} ", board[i, j]));
        //        }
        //        Console.Write(Environment.NewLine + Environment.NewLine);
        //    }
        //    Console.ReadLine();
        //}


        //Get the board (including vehicles) as a string.
        //This is used for comparing two boards.
        public string getBoardString()
        {
            char[] boardCharArray = new char[size * size];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //Add '.' if there is no vehicle on current position.
                    boardCharArray[j + (i * size)] = '.';

                    if (board[i, j] is Car)
                    {
                        ////Add name of the vehicle to the board.
                        //Car tempCar = (Car)board[i,j];
                        //boardCharList.Add(tempCar.getName());
                        //tempCar = null;

                        //Add 'c' if there is a car on current position.
                        boardCharArray[j + (i * size)] = 'c';
                    }
                    if (board[i, j] is Truck)
                    {
                        //Add 't' if there is a truck on current position.
                        boardCharArray[j + (i * size)] = 't';
                    }
                    if (board[i, j] is RedCar)
                    {
                        //Add 'r' if the red car is on current position.
                        boardCharArray[j + (i * size)] = 'r';
                    }
                }
            }

            return new string(boardCharArray);
        }
    }
}
