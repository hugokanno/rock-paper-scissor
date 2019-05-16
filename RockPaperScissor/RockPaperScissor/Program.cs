using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    class Program
    {
        public static List<Player> Players { get; set; }

        public static void RandomPlayers(int num)
        {
            Players = new List<Player>();
            Random rng = new Random();
            int aux = rng.Next(0, 3); ;
            for (int i = 0; i < num; i++)
            {
                if (aux == 0)
                    Players.Add(new Player("Player" + (i + 1), "R"));
                if (aux == 1)
                    Players.Add(new Player("Player" + (i + 1), "P"));
                if (aux == 2)
                    Players.Add(new Player("Player" + (i + 1), "S"));
                aux = rng.Next(0, 3);
            }
        }

        public static int Winner(string player1, string player2)
        {
            if (player1.Equals('P') && player2.Equals('R'))
                return 1;
            if (player1.Equals('R') && player2.Equals('S'))
                return 1;
            if (player1.Equals('S') && player2.Equals('P'))
                return 1;

            if (player1.Equals(player2))
                return 1;
            else
                return 2;
        }

        private static void Tournament(int num)
        {
            Console.Clear();
            int total = Players.Count();
            int n = 1, pull = 2;
            bool win = false;

            while(!win)
            {
                for (int i = 0; i < total-1; i+=pull)
                {
                    if (i + n < total)
                    {
                        Console.WriteLine("[" + Players.ElementAt(i).Name + "," + Players.ElementAt(i).Move + "] X [" + Players.ElementAt(i + n).Name + "," + Players.ElementAt(i + n).Move + "]");
                        if (Winner(Players.ElementAt(i).Move, Players.ElementAt(i + n).Move) == 1)
                            Console.WriteLine("Winner : [" + Players.ElementAt(i).Name + "," + Players.ElementAt(i).Move + "]");
                        else
                        {
                            Console.WriteLine("Winner : [" + Players.ElementAt(i + n).Name + "," + Players.ElementAt(i + n).Move + "]");
                            Players.ElementAt(i).Name = Players.ElementAt(i + n).Name;
                            Players.ElementAt(i).Move = Players.ElementAt(i + n).Move;
                        }
                        Console.ReadKey();
                    }
                    else
                        win = true;
                }
                pull *= 2;
                n = Convert.ToInt32(Math.Pow(2, n++));
                if (pull > total)

                Console.WriteLine("\n");
                Console.WriteLine("\n");
            }
            Console.WriteLine("[" + Players.ElementAt(0).Name + "," + Players.ElementAt(0).Move + "] X [" + Players.ElementAt(total / 2).Name + "," + Players.ElementAt(total / 2) + "]");
            if (Winner(Players.ElementAt(0).Move, Players.ElementAt(total / 2).Move) == 1)
                Console.WriteLine("Winner of the Tournament : [" + Players.ElementAt(0).Name + "," + Players.ElementAt(0).Move + "]");
            else
                Console.WriteLine("Winner of the Tournament : [" + Players.ElementAt(total / 2).Name + "," + Players.ElementAt(total / 2).Move + "]");

            Console.ReadKey();
        }

        private static bool ValidatePlayers(int num)
        {
            for (int i = 0; i < 200; i++)
            {
                if (Math.Pow(2, i) == num)
                    return true;
            }
            return false;
        }

        private static void ShowPlayers()
        {
            foreach(var x in Players)
            {
                Console.WriteLine("[" + x.Name + "," + x.Move + "]");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("** Rock, Paper and Scissor Tournament **");
            Console.WriteLine("** Insert the number of Players(2^n)!**");
            string texto = "";
            texto = Console.ReadLine();
            int num = 0;
            bool sucess = Int32.TryParse(texto, out num);

            while (!sucess || !ValidatePlayers(num))
            {
                Console.WriteLine("** Wrong number of Players! Try Again! **");
                Console.WriteLine("** Insert the number of Players(2^n)!**");
                texto = Console.ReadLine();
                num = 0;
                sucess = Int32.TryParse(texto, out num);
            }
            RandomPlayers(num);
            Console.WriteLine("** Displaying Players! **");
            ShowPlayers();
            Console.ReadKey();

            Console.WriteLine("\n");
            Console.WriteLine("** Press any key to start the Tournament **");
            Console.ReadKey();
            Tournament(num);
        }
    }
}
