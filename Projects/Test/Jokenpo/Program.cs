using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private enum StrategyWeight
        {
            R = 3,
            S = 2,
            P = 1
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome!");
            Console.WriteLine();
            //IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<string>>>>> tournament
            var tournament = new List<List<List<Dictionary<string, string>>>>
            {
                new List<List<Dictionary<string, string>>>
                {
                    new List<Dictionary<string, string>>
                    {
                        new Dictionary<string, string>
                        {
                            { "Armando", "P" }, { "Dave", "S" }
                        },
                        new Dictionary<string, string>
                        {
                            { "Richard", "R" }, { "Michael", "S" }
                        }
                    },
                    new List<Dictionary<string, string>>
                    {
                        new Dictionary<string, string>
                        {
                            { "Allen", "S" }, { "Omer", "P" }
                        },
                        new Dictionary<string, string>
                        {
                            { "David E.", "R" }, { "Richard X.", "P" }
                        }
                    }
                }
            };

            RockPaperScissors(tournament);

            Console.ReadKey();

        }

        /// <summary>
        /// R > S | S > P | P > R
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static string Rps_Game_Winner(IEnumerable<string> p1, IEnumerable<string> p2)
        {
            if(p1.Count() <= 0 && p2.Count() <= 0)
            {
                return "";
            }

            var p1Name = p1.First();
            var p1Strategy = p1.Last();

            var p2Name = p2.First();
            var p2Strategy = p2.Last();


            if (!ValuesIsValid(p1Strategy, p2Strategy))
            {
                return null;
            }

            if (p1Strategy.Equals(p2Strategy))
            {
                return p1Name;
            }

            var winnerStrategyIs = ReturnWinnerStrategy(p1Strategy, p2Strategy);

            return winnerStrategyIs.Equals(p1Strategy) ? p1Name : p2Name;
        }

        private static string ReturnWinnerStrategy(string v1, string v2)
        {
            Enum.TryParse(v1, out StrategyWeight strategyWeight1);
            Enum.TryParse(v2, out StrategyWeight strategyWeight2);

            var sum = (int)strategyWeight1 + (int)strategyWeight2;
            
            switch (sum)
            {
                case 5: return "R";
                case 4: return "P";
                case 3: return "S";
                default: return null;
            }
        }

        private static bool ValuesIsValid(string v1, string v2)
        {
            var allowedValues = new string[] { "R", "P", "S" };

            if(!allowedValues.Contains(v1) || !allowedValues.Contains(v2))
            {
                return false;
            }

            if (v1 != v1.ToUpper() || v2 != v2.ToUpper())
            {
                return false;
            }

            return true;
        }

        private static void RockPaperScissors(List<List<List<Dictionary<string, string>>>> tournament)
        {
            var dic = new Dictionary<string, string>();

            foreach (List<List<Dictionary<string, string>>> level0 in tournament)
            {   
                foreach (List<Dictionary<string, string>> level1 in level0)
                {
                    var result = GetWinner(level1);
                    dic.Add(result.Key, result.Value);                    
                }
            }

            var winner = GetWinner(dic);
        }

        private static KeyValuePair<string, string> GetWinner(Dictionary<string, string> dic)
        {
            var player1 = default(KeyValuePair<string, string>);
            var playerWinner = default(KeyValuePair<string, string>);

            foreach (KeyValuePair<string, string> player in dic)
            {
                if (player1.Key == default(KeyValuePair<string, string>).Key &&
                    player1.Value == default(KeyValuePair<string, string>).Value)
                {
                    player1 = player;
                    continue;
                }

                var winnerName = Rps_Game_Winner(new string[] { player1.Key, player1.Value }, new string[] { player.Key, player.Value });
                Console.WriteLine(string.Format("{0} vs {1}", player1.Key, player.Key));
                Console.WriteLine(string.Format("Winner:{0}", winnerName));
                Console.WriteLine();
                playerWinner = winnerName.Equals(player1.Key) ? player1 : player;
            }

            dic.Remove(dic.First().Key);

            if (dic.Count() > 1)
            {
                var player2 = GetWinner(dic);
                var resultGame = Rps_Game_Winner(new string[] { playerWinner.Key, playerWinner.Value }, new string[] { player2.Key, player2.Value });
                Console.WriteLine(string.Format("{0} vs {1}", playerWinner.Key, player2.Key));
                Console.WriteLine(string.Format("Winner:{0}", resultGame));
                Console.WriteLine();
                return resultGame.Equals(playerWinner.Key) ? playerWinner : player2;
            }
            else
            {
                return playerWinner;
            }
        }

        private static KeyValuePair<string, string> GetWinner(List<Dictionary<string, string>> level1)
        {   
            var player1 = default(KeyValuePair<string, string>);
            var playerWinner = default(KeyValuePair<string, string>);

            foreach (KeyValuePair<string, string> player in level1[0])
            {
                if (player1.Key == default(KeyValuePair<string, string>).Key &&
                    player1.Value == default(KeyValuePair<string, string>).Value)
                {
                    player1 = player;
                    continue;
                }

                
                var winnerName = Rps_Game_Winner(new string[] { player1.Key, player1.Value }, new string[] { player.Key, player.Value });
                Console.WriteLine(string.Format("{0} vs {1}", player1.Key, player.Key));
                Console.WriteLine(string.Format("Winner:{0}", winnerName));
                Console.WriteLine();
                playerWinner = winnerName.Equals(player1.Key) ? player1 : player;
            }

            level1.Remove(level1[0]);

            if (level1.Count() > 0)
            {
                var player2 = GetWinner(level1);
                var resultGame = Rps_Game_Winner(new string[] { playerWinner.Key, playerWinner.Value }, new string[] { player2.Key, player2.Value });
                Console.WriteLine(string.Format("{0} vs {1}", playerWinner.Key, player2.Key));
                Console.WriteLine(string.Format("Winner:{0}", resultGame));
                Console.WriteLine();
                return resultGame.Equals(playerWinner.Key) ? playerWinner : player2;
            }
            else
            {
                return playerWinner;
            }
        }
    }
}
