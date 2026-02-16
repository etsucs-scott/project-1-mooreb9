namespace AdventureGame.Core
{
    public abstract class Item
    {
        public Item()
        {
            
        }

        public abstract void Apply(Player player);
    }
}