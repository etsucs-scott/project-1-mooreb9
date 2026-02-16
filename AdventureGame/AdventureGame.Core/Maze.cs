namespace AdventureGame.Core
{
    public class Maze
    {
        public int MazeWidth { get; private set; }
        public int MazeHeight { get; private set; }

        public Tiles[,] MazeGrid { get; private set; }

        public Maze(int width, int height, Random random)
        {
            MazeWidth = width;
            MazeHeight = height;
            MazeGrid = new Tiles[width, height];

            Generate(random);
        }

        public void Generate(Random random)
        {
            for (int x = 0; x < MazeWidth; x++)
            {
                for (int y = 0; y < MazeHeight; y++)
                {
                    if (x == 0 || y == 0 || x == MazeWidth - 1 || y == MazeHeight - 1)
                    {
                        MazeGrid[x, y] = Tiles.Wall;
                    }
                    else
                    {
                        int randomNumber = random.Next(100);

                        if (randomNumber < 25)
                        {
                            MazeGrid[x, y] = Tiles.Wall;
                        }
                        else if (randomNumber < 35)
                        {
                            MazeGrid[x, y] = Tiles.Monster;
                        }
                        else if (randomNumber < 40)
                        {
                            MazeGrid[x, y] = Tiles.Weapon;
                        }
                        else if (randomNumber < 43)
                        {
                            MazeGrid[x, y] = Tiles.Potion;
                        }
                        else
                        {
                            MazeGrid[x, y] = Tiles.Empty;
                        }
                    }
                }
            }

            MazeGrid[1, 1] = Tiles.Empty;
            MazeGrid[1, 2] = Tiles.Empty;
            MazeGrid[2, 1] = Tiles.Empty;

            MazeGrid[MazeWidth - 2, MazeHeight - 3] = Tiles.Empty;
            MazeGrid[MazeWidth - 3, MazeHeight - 2] = Tiles.Empty;
            MazeGrid[MazeWidth - 2, MazeHeight - 2] = Tiles.Exit;
        }
    }
}

