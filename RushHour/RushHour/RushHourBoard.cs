using System;
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
        char[,] board;

        public RushHourBoard()
        {
            width = size;
            height = size;
            initBoard();
        }

        public void initBoard(){
            board = new char[size, size];

            //set all x and y values to . when spots are taken we change their values to a char responding the vehicle
            for (int k = 0; k < board.GetLength(0); k++)
                for (int l = 0; l < board.GetLength(1); l++)
                    board[k, l] = '.';

            //print board - test
            for (int k = 0; k < board.GetLength(0); k++)
                for (int l = 0; l < board.GetLength(1); l++)
                    Console.WriteLine(board[k, l]);
                    Console.ReadLine();
                    
        }


    }
}
