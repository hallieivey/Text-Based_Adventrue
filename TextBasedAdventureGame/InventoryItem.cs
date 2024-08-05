//Hallie Ivey (hivey@cnm.edu)
//JUL 2024
//P7 - Adventure Game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//InventoryItem class inherits from GameObject and uses the IPortable interface
//Inventory items can be picked up by player and do not contain another GameObject to be SEARCHED
namespace TextBasedAdventureGame
{
    public class InventoryItem: GameObject, IPortable
    {
        public int Size
        { get; set; }

        public decimal Price
        { get; set; }

        public InventoryItem():base()
        {
            Size = 0;
        }

        public InventoryItem(string description):this(description, 1, 0.0M)
        { 
        }
        public InventoryItem(string description, int size):this (description, size, 0.0M)
        {

        }
        public InventoryItem(string description, int size, decimal price)
        {
            Description = description;
            Size = size;
            Price = price;
        }
    }
}
