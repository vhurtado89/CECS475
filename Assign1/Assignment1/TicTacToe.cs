using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class TicTacToe
    {
        private const int _BOARDSIZE = 3;
        private int[,] _board = new int[3, 3];
        private int _player;
        

        public TicTacToe()
        {
            clear();
            _player = 1;
        }
        public int[,] Board{
            get
            {
                return _board;
            }
            set
            {
                _board = value;
            }
        }        
        public int Player
        {
            get
            {
                return _player;
            }
         
        }

        public void PrintBoard()
        {
            Console.WriteLine("------------------------");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("|       |       |       |");
              //  Console.WriteLine("|       |       |       |");
                Console.Write("|   ");
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i, j] != 0)
                    {
                        Console.Write(_board[i, j] + "   |   ");
                    }
                    else
                    {
                        Console.Write("    |   ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("|       |       |       |");
                
                Console.WriteLine("------------------------");
            }
        }
        public void Play()
        {
            int x = 0, y = 0;
            Boolean taken = false;
            Console.WriteLine("Player" + _player + "'s turn");
            while (!taken)
            {
                Console.WriteLine("Player " + _player + ": Enter row(0 <= row < 3): ");
                x = checkInput();
                Console.WriteLine("Player " + _player + ": Enter column(0 <= row < 3): ");
                y = checkInput();
                if (checkPosition(x, y))
                {
                    taken = true;
                }
                else
                {
                    Console.WriteLine("That position is taken, try again");
                }

            }
            _board[x, y] = _player;

        }
        public void playerChange()
        {
            if (_player == 1)
            {
                _player = 2;
            }
            else
            {
                _player = 1;
            }
        }

        public Boolean checkWinner(int x)   
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] == x && _board[i, 1] == x && _board[i, 2] == x)
                {
                    return true;
                }
                if (_board[0, i] == x && _board[1, i] == x && _board[2, i] == x)
                {
                    return true;
                }             
            }
            if (_board[0, 0] == x && _board[1, 1] == x && _board[2, 2] == x)
            {
               return true;
            }
            if (_board[0, 2] == x && _board[0, 1] == x && _board[2, 0] == x)
            {
                return true;
            }
            else
                return false;
        }
        public Boolean checkTie()
        {
            Boolean tie = false;
            int count = 0;
            for (int i = 0; i < _BOARDSIZE; i++)
            {
                for (int j = 0; j < _BOARDSIZE; j++)
                {
                    if (_board[i, j] != 0) { count++; }
                }
            }
            if (count > 8)
            {
                tie = true;
            }
            return tie;
        }
        public void clear()
        {
            for (int i = 0; i < _BOARDSIZE; i++)
            {
                for (int j = 0; j < _BOARDSIZE; j++)
                {
                    _board[i, j] = 0;
                }
            }
        }    
        
        public int checkInput()
        {
            int x=0;
            Boolean correct = false;           
            while (!correct)
            {
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    //x = Convert.ToInt32(Console.ReadLine());
                    if (x >= 0 && x < 3)
                    {
                        correct = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input try again");
                    }
                }
                else
                {
                    Console.WriteLine("Input was a letter, try again");
                }
               
            }
            return x;
        }
        public Boolean checkPosition(int a, int b)
        {
            Boolean notTaken = true;
            if (_board[a, b] != 0)
            {
                notTaken = false;
            }

                return notTaken;
        }
    }
}
