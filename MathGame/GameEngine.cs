using MathGame.Models;
using System.Diagnostics;

namespace MathGame
{
    internal class GameEngine
    {
        internal void RandomGame()
        {
            Array values = Enum.GetValues(typeof(GameType));

            Random random = new Random();

            GameType gameType = (GameType)values.GetValue(random.Next(values.Length));

            StartGame(gameType);

        }

        internal void StartGame(GameType gameType)
        {
            Console.Clear();

            Stopwatch timer = new Stopwatch();

            timer.Start();

            var totalGames = 2;

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            string operatorSymbol = gameType switch
            {
                GameType.Addition => "+",
                GameType.Subtraction => "-",
                GameType.Multiplication => "*",
                GameType.Division => "/",
                _ => throw new ArgumentException("Invalid operation")
            };

            for (int i = 0; i < totalGames; i++)
            {
                if (gameType == GameType.Division)
                {
                    var divisionNumbers = Helpers.GetDivisionNumbers();
                    firstNumber = divisionNumbers[0];
                    secondNumber = divisionNumbers[1];
                }
                else
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }

                Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                int correctAnswer = gameType switch
                {
                    GameType.Addition => firstNumber + secondNumber,
                    GameType.Subtraction => firstNumber - secondNumber,
                    GameType.Multiplication => firstNumber * secondNumber,
                    GameType.Division => firstNumber / secondNumber,
                    _ => throw new ArgumentException("Invalid operation")
                };

                if (int.Parse(result) == correctAnswer)
                {
                    Console.WriteLine($"Your answer was correct.");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Your answer was incorrect.");
                }
            }

            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to the main menu.");
            Console.ReadKey();

            Helpers.AddScore(gameType, score, timer.Elapsed);

        }
    }
}
