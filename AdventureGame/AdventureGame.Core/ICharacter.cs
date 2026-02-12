using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public interface ICharacter
    {
        public int Attack(int damage);

        public void TakeDamage(int damage);
    }
}
