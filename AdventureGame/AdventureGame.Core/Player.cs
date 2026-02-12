namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        private const int BaseDamage = 10;
        private const int MaxHealth = 150;

        public int Health { get; private set; } = 100;

        public bool IsAlive => Health > 0;

        public List<Weapon> Inventory { get; } = new();

        public int Attack(int damage)
        {
            int bestModifier = Inventory.Any()
                ? Inventory.Max(w => w.AttackModifier)
                : 0;

            // I used ChatGPT 5.2 to pull the max attack modifier from the inventory list 
            // (Gillenwater did not go over lists in my section of 1250, so this is my first time using them)

            return BaseDamage + bestModifier;
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}

