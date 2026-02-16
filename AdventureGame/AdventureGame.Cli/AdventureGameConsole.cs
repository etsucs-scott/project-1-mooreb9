using AdventureGame.Core;
using System;

class Program
{
    static void Main()
    {
        var game = new GameEngine();

        while (!game.IsGameOver)
        {
            Console.Clear();
            Draw(game);

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    game.Move(0, -1);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    game.Move(0, 1);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    game.Move(-1, 0);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    game.Move(1, 0);
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine(game.IsVictory ? "You escaped!" : "Game Over!");
    }

    static void Draw(GameEngine game)
    {
        for (int y = 0; y < game.Maze.MazeHeight; y++)
        {
            for (int x = 0; x < game.Maze.MazeWidth; x++)
            {
                if (x == game.PlayerX && y == game.PlayerY)
                    Console.Write("@ ");
                else
                {
                    switch (game.Maze.MazeGrid[x, y])
                    {
                        case Tiles.Wall: Console.Write("# "); break;
                        case Tiles.Monster: Console.Write("M "); break;
                        case Tiles.Potion: Console.Write("P "); break;
                        case Tiles.Weapon: Console.Write("W "); break;
                        case Tiles.Exit: Console.Write("E "); break;
                        default: Console.Write(". "); break;
                    }
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\nHP: {game.Player.Health}");
        Console.WriteLine(game.LastMessage);
    }
}

