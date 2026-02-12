using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public int healthBoost = 20;

        public Potion() 
        : base("potion", "You gain 20 HP!") { }
    }
}
