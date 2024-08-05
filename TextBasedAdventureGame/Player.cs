//Hallie Ivey (hivey@cnm.edu)
//JUL 2024
//P7 - Adventure Game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TextBasedAdventureGame
{
    //Player class represents the player and their current location and inventory
    //HI- added a TotalPrice method to calc the price of the players inventory
    public class Player
    {
        private int inventorySize;
        public int MaxInventory
        { get; set; }

        /// <summary>
        /// Inventory contains portable game objects the player is holding
        /// </summary>
        public List<IPortable> Inventory
        { get; set; }

        ///<summary>
        ///Player's Location
        ///</summary>
        public MapLocation Location
        { get; set; }

        public Player():this(null)
        {}
        public Player (MapLocation location)
        {
            Location = location;
            MaxInventory = 7; 
            Inventory = new List<IPortable> ();
            AddInventoryItem(new InventoryItem("Pack of Gum",1));
        }

        /// <summary>
        /// AddInventory will add the item given if it will fit based on MaxInventory
        /// return true if it can be carried
        /// returns false if item is too large
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddInventoryItem(IPortable item)
        {
            bool canCarryItem = true;
            if (item.Size + inventorySize <= MaxInventory)
            {
                //player can carry item
                Inventory.Add (item);
                Calc();
            }
            else
            {
                //player cannot carry item
                canCarryItem = false;
            }
            return canCarryItem;
        }

        /// <summary>
        /// Removes item from Inventory 
        /// </summary>
        /// <param name="item"></param>
        public void RemoveInventoryItem(IPortable item)
        {
            Inventory.Remove(item);
            Calc();
        }

        /// <summary>
        /// Calc resets inventory size to the sum of each object in Inventory
        /// </summary>
        private void Calc()
        {
            inventorySize = 0;
            foreach (var element in Inventory)
            {
                inventorySize += element.Size;
            }
        }

        public string TotalPrice()
        {
            decimal price = 0;
            foreach (var element in Inventory)
            {
                price += element.Price;
            }
            return price.ToString("c");
        }
    }
}
