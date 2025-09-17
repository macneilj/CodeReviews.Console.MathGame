using MathGame.Models;

namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new GameEngine();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Hello, {name.ToUpper()}! Welcome to da Math Game? Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        H - Score History
        R - Random Game
        Q - Quit the program"
                );
                Console.WriteLine("---------------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        gameEngine.StartGame(GameType.Addition);
                        break;
                    case "s":
                        gameEngine.StartGame(GameType.Subtraction);
                        break;
                    case "m":
                        gameEngine.StartGame(GameType.Multiplication);
                        break;
                    case "d":
                        gameEngine.StartGame(GameType.Division);
                        break;
                    case "h":
                        Helpers.PrintScores();
                        break;
                    case "r":
                        gameEngine.RandomGame();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
