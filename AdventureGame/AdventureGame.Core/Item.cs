using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public abstract class Item
    {
        public string Name { get; private set; }
        public string PickupMessage { get; private set; }

        public Item(string name, string pickupMessage)
        {
            Name = name;
            PickupMessage = pickupMessage;
        }
    }
}