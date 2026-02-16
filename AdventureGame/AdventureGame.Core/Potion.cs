namespace AdventureGame.Core
{
    public class Potion : Item
    {
        private const int HealAmount = 20;

        public Potion() : base()
        {
        }

        public override void Apply(Player player)
        {
            player.Heal(HealAmount);
        }
    }
}

