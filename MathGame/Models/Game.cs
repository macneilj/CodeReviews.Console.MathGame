using System.Diagnostics;

namespace MathGame.Models;
internal class Game
{
    //private int _score;

    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public TimeSpan Time { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}