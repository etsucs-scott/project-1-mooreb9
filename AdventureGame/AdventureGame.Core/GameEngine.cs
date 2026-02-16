

namespace AdventureGame.Core
{
    public class GameEngine
    {
        private readonly Random _random = new();
        public Player Player { get; }
        public Maze Maze { get; }

        public int PlayerX { get; private set; }
        public int PlayerY { get; private set; }

        public bool IsGameOver { get; private set; }
        public bool IsVictory { get; private set; }

        public string LastMessage { get; private set; } = "";

        public GameEngine()
        {
            Player = new Player();
            Maze = new Maze(10, 10, _random);

            PlayerX = 1;
            PlayerY = 1;
        }

        public void Move(int dx, int dy)
        {
            int newX = PlayerX + dx;
            int newY = PlayerY + dy;

            if (Maze.MazeGrid[newX, newY] == Tiles.Wall)
            {
                LastMessage = "A wall blocks your path!";
                return;
            }
            else if (Maze.MazeGrid[newX, newY] == Tiles.Weapon)
            {
                LastMessage = "You got a weapon!";
            }
            else if (Maze.MazeGrid[newX, newY] == Tiles.Potion)
            {
                LastMessage = "You drank a potion, + 20 HP";
            }
            PlayerX = newX;
            PlayerY = newY;

            HandleTile();
        }

        private void HandleTile()
        {
            var tile = Maze.MazeGrid[PlayerX, PlayerY];

            switch (tile)
            {
                case Tiles.Monster:
                    Battle();
                    Maze.MazeGrid[PlayerX, PlayerY] = Tiles.Empty;
                    break;

                case Tiles.Weapon:
                    SpawnWeapon().Apply(Player);
                    Maze.MazeGrid[PlayerX, PlayerY] = Tiles.Empty;
                    break;

                case Tiles.Potion:
                    SpawnPotion().Apply(Player);
                    Maze.MazeGrid[PlayerX, PlayerY] = Tiles.Empty;
                    break;

                case Tiles.Exit:
                    IsVictory = true;
                    IsGameOver = true;
                    break;
            }
        }

        private void Battle()
        {
            var monster = new Monster(_random);

            while (Player.IsAlive && monster.IsAlive)
            {
                monster.TakeDamage(Player.Attack());

                if (monster.IsAlive)
                    Player.TakeDamage(monster.Attack());
            }

            if (!Player.IsAlive)
                IsGameOver = true;
            else
                LastMessage = "Monster defeated!";
        }

        private Potion SpawnPotion()
        {
                return new Potion();
        }

        private Weapon SpawnWeapon()
        {
            Random random = new Random();     
            int weaponDamage = random.Next(10, 31);
            return new Weapon(weaponDamage);
        }
    }
}
