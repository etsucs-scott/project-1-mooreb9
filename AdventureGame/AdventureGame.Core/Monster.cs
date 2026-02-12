namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        public int Health { get; private set; }

        public bool IsAlive => Health > 0;
        public int Attack(int damage)
        {
            return damage;
        }
        public void TakeDamage(int damage)
        {

        }
    }
}

