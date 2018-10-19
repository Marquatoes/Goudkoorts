using Goudkoorts.Controller;
using System;
using static Goudkoorts.Game;

namespace Goudkoorts
{
    public class GameView
    {
        private GameController _gameController;
        public GameView(GameController gc)
        {
            _gameController = gc;
        }
        public void Update(object sender, UpdateEventArgs args)
        {
            if (args.FieldChanged)
            {
                Console.Clear();

                ImmovableObject First = _gameController.GetPathFirst();

                var rowindex = 0;
                var cellindex = 0;
                for (var row = First; row != null; row = row.Down)
                {
                    rowindex++;
                    cellindex = 0;
                    for (var cell = row; cell != null; cell = cell.Right)
                    {
                        cellindex++;

                        if (cell is Track)
                        {
                            if(cell is Yard)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }

                            if (cell is Flat || cell is Yard)
                            {
                                if (!IsNullOrEmpty(cell.Left) && !IsNullOrEmpty(cell.Right) && IsNullOrEmpty(cell.Up) && IsNullOrEmpty(cell.Down)
                                    || !IsNullOrEmpty(cell.Left) && IsNullOrEmpty(cell.Right) && IsNullOrEmpty(cell.Up) && IsNullOrEmpty(cell.Down)
                                    || IsNullOrEmpty(cell.Left) && !IsNullOrEmpty(cell.Right) && IsNullOrEmpty(cell.Up) && IsNullOrEmpty(cell.Down))
                                    Console.Write("═");
                                if (IsNullOrEmpty(cell.Left) && IsNullOrEmpty(cell.Right) && !IsNullOrEmpty(cell.Up) && !IsNullOrEmpty(cell.Down)
                                    || IsNullOrEmpty(cell.Left) && IsNullOrEmpty(cell.Right) && !IsNullOrEmpty(cell.Up) && IsNullOrEmpty(cell.Down)
                                    || IsNullOrEmpty(cell.Left) && IsNullOrEmpty(cell.Right) && IsNullOrEmpty(cell.Up) && !IsNullOrEmpty(cell.Down))
                                    Console.Write("║");
                                if (!IsNullOrEmpty(cell.Left) && IsNullOrEmpty(cell.Right) && !IsNullOrEmpty(cell.Up) && IsNullOrEmpty(cell.Down))
                                    Console.Write("╝");
                                if (IsNullOrEmpty(cell.Left) && !IsNullOrEmpty(cell.Right) && !IsNullOrEmpty(cell.Up) && IsNullOrEmpty(cell.Down))
                                    Console.Write("╚");
                                if (IsNullOrEmpty(cell.Left) && !IsNullOrEmpty(cell.Right) && IsNullOrEmpty(cell.Up) && !IsNullOrEmpty(cell.Down))
                                    Console.Write("╔");
                                if (!IsNullOrEmpty(cell.Left) && IsNullOrEmpty(cell.Right) && IsNullOrEmpty(cell.Up) && !IsNullOrEmpty(cell.Down))
                                    Console.Write("╗");
                            }

                            if (cell is Switch sw)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                if (!IsNullOrEmpty(sw.Left) && sw.Lane == sw.Up)
                                    Console.Write("╝");
                                if (!IsNullOrEmpty(sw.Left) && sw.Lane == sw.Down)
                                    Console.Write("╗");
                                if (!IsNullOrEmpty(cell.Right) && sw.Lane == sw.Up)
                                    Console.Write("╚");
                                if (!IsNullOrEmpty(cell.Right) && sw.Lane == sw.Down)
                                    Console.Write("╔");
                            }

                            if (cell is Dock)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write('¥');
                            }
                        }
                        else if(cell is StartingPoint)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('§');
                        }
                        else
                            Console.Write(' ');
                        
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }

        private bool IsNullOrEmpty(ImmovableObject c)
        {
            return c == null || c is Empty;
        }
    }
}