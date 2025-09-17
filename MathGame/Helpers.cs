using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();

        internal static string GetName()
        {
            Console.WriteLine("Please type your name:");

            var name = Console.ReadLine();

            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty");
                name = Console.ReadLine();
            }

            return name;
        }

        internal static void PrintScores()
        {

            Console.Clear();

            if (games.Count() == 0)
            {
                Console.WriteLine("Score History is empty. Try playing a game.");
            }
            else
            {
                Console.WriteLine("Score History:");

                foreach (var game in games)
                {
                    Console.WriteLine($"Date: {game.Date}\nGame: {game.Type} - Score: {game.Score} - Time Elapsed: {game.Time}");
                }

                Console.WriteLine("---------------------------------------------");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        internal static void AddScore(GameType game, int score, TimeSpan time)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = game,
                Time = time
            });
        }

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            var result = new int[2];

            result[0] = firstNumber;
            result[1] = secondNumber;

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(0, 99);
                secondNumber = random.Next(0, 99);
                result[0] = firstNumber;
                result[1] = secondNumber;
            }

            Console.WriteLine(result);

            return result;
        }

        internal static string ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }

            return result;
        }
    }

}
