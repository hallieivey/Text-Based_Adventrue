//Hallie Ivey (hivey@cnm.edu)
//JUL 2024
//P7 - Adventure Game
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PortableHidingPlace inherits from GameObject and utilizes both
//IPortable and IHidingPlace and is an item that can be picked up
//by the player and also SEARCHED to find another GameObject
namespace TextBasedAdventureGame
{
    public class PortableHidingPlace: GameObject, IPortable, IHidingPlace
    {
        private GameObject item;
        public GameObject HiddenObject 
        {
            get { return item; }
            set {  item = value; } 
        }

        public int Size
        { get; set; }
        public decimal Price
        { get; set; }

        public PortableHidingPlace():this("mysterious object", 0, null, 0.0M)
        { }
        public PortableHidingPlace(string description) : this(description, 0, null, 0.0M)
        { }
        public PortableHidingPlace(string description, int size, GameObject hiddenObject) : this(description, size, hiddenObject, 0.0M)
        { }
        public PortableHidingPlace (string description, int size,  GameObject hiddenObject, decimal price)
        {
            HiddenObject = hiddenObject;
            Size = size;
            Description = description;
            Price = price;
        }

        //methods
        public GameObject Search()
        {
            //could inherit from HidingPlace to avoid redundant search method
            GameObject temp = HiddenObject;
            HiddenObject = null;
            return temp;
        }
    }
}
