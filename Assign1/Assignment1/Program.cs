/*
 *  Victor Hurtado
 * Assignment 1 Tic Tac Toe
 * CECS 475
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            Boolean won = false;
            while (!won)
            {
                game.PrintBoard();
                game.Play();
                if (game.checkWinner(game.Player))
                {
                    game.PrintBoard();
                    Console.WriteLine("Player " + game.Player + " has won");
                    won = true;
                }
                if (game.checkTie())
                {
                    game.PrintBoard();
                    Console.WriteLine("The game is a tie");
                    won = true;
                }
                game.playerChange();
                
            }          
        }
    }
}
