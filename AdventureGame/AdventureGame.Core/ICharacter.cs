namespace AdventureGame.Core
{
    public interface ICharacter
    {
        public int Attack();

        public void TakeDamage(int damage);
    }
}
