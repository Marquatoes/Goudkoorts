using Goudkoorts.Controller;
using System;
using static Goudkoorts.Game;

namespace Goudkoorts
{
    public class GameView
    {
        private GameController _gameController;
        private int boatCount;
        private string[] boatArr;
        public GameView(GameController gc)
        {
            _gameController = gc;
            boatCount = 0;
            boatArr = new string[31];
            boatArr[0] = "~~~~~~~~~~~~~~";
            boatArr[1] = ">~~~~~~~~~~~~~";
            boatArr[2] = "░>~~~~~~~~~~~~";
            boatArr[3] = "░░>~~~~~~~~~~~";
            boatArr[4] = "░░░>~~~~~~~~~~";
            boatArr[5] = "░░░░>~~~~~~~~~";
            boatArr[6] = "░░░░░>~~~~~~~~";
            boatArr[7] = "<░░░░░>~~~~~~~";
            boatArr[8] = "~<░░░░░>~~~~~~";
            boatArr[9] = "~~<░░░░░>~~~~~";
            boatArr[10] = "~~~<░░░░░>~~~~";
            boatArr[11] = "~~~~<░░░░░>~~~";
            boatArr[12] = "~~~~~<░░░░░>~~";
            boatArr[13] = "~~~~~~<░░░░░>~";
            boatArr[14] = "~~~~~~~<░░░░░>";
            boatArr[15] = "~~~~~~~<▄░░░░>";
            boatArr[16] = "~~~~~~~<█░░░░>";
            boatArr[17] = "~~~~~~~<█▄░░░>";
            boatArr[18] = "~~~~~~~<██░░░>";
            boatArr[19] = "~~~~~~~<██▄░░>";
            boatArr[20] = "~~~~~~~<███░░>";
            boatArr[21] = "~~~~~~~<███▄░>";
            boatArr[22] = "~~~~~~~<████░>";
            boatArr[23] = "~~~~~~~<████▄>";
            boatArr[24] = "~~~~~~~<█████>";
            boatArr[25] = "~~~~~~~~<█████";
            boatArr[26] = "~~~~~~~~~<████";
            boatArr[27] = "~~~~~~~~~~<███";
            boatArr[28] = "~~~~~~~~~~~<██";
            boatArr[29] = "~~~~~~~~~~~~<█";
            boatArr[30] = "~~~~~~~~~~~~~<";
        }
        public void Update(object sender, EventArgs args)
        {
            Console.Clear();

            #region Boat drawing
            string BoatLane = GetBoatLaneString();
            if (!_gameController.BoatIsAtDock)
            {
                boatCount++;
            }

            Console.WriteLine("┌────────────┐");
            Console.WriteLine("~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~");
            Console.WriteLine(BoatLane);

            #endregion

            #region Map drawing
            ImmovableObject First = _gameController.GetPathFirst();

            var rowindex = 0;
            var cellindex = 0;
            for (var row = First; row != null; row = row.Down)
            {
                rowindex++;
                cellindex = 0;

                Console.Write("│");
                for (var cell = row; cell != null; cell = cell.Right)
                {
                    cellindex++;
                    if(cell.InUseBy() != null)
                    {
                        if(cell.InUseBy() is Cart fullCart && fullCart.IsFull)
                        {
                            Console.Write("Ü");
                        }
                        else if (cell.InUseBy() is Cart emptyCart && !emptyCart.IsFull)
                        {
                            Console.Write("U");
                        }
                    }
                    else if (cell is Track)
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
                    else Console.Write(' ');
                        
                    Console.ResetColor();
                }
                Console.WriteLine("│");
            }
            #endregion
        }

        private string GetBoatLaneString()
        {
            boatCount = boatCount == 31 ? 0 : boatCount;
            var val = boatArr[boatCount];
            return val;
        }

        private bool IsNullOrEmpty(ImmovableObject c)
        {
            return c == null || c is Empty;
        }
    }
}