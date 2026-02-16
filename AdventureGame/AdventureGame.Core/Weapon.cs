using System;

namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public int AttackModifier { get; }

        public Weapon(int WeaponDamage) : base()
        {
            AttackModifier = WeaponDamage;
        }

        public override void Apply(Player player)
        {
            player.AddWeapon(this);
        }
    }
}
