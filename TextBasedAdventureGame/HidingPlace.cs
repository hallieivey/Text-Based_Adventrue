//HidingPlace.cs
//Hallie Ivey (hivey@cnm.edu)
//P7 JUL2024
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//HidingPlace is a class that inherits GameObject and IHidingPlace and is 
//utilized when an object can not be picked up by player but can be SEARCHED
//to find another GameObject
namespace TextBasedAdventureGame
{
    public class HidingPlace:GameObject, IHidingPlace
    {
        private GameObject hiddenObject;

        public GameObject HiddenObject
        { 
            get { return hiddenObject; }
            set { hiddenObject = value; }
        }

        public HidingPlace(): this ("mysterious place", null)
        { }
        public HidingPlace(string description):this(description, null)
        { }

        public HidingPlace(string description, GameObject hiddenObject)
        {
            HiddenObject = hiddenObject;
            Description = description;
        }

        /// <summary>
        /// Search will clear any hidden object stored   
        /// </summary>
        /// <returns>
        /// GameObject hidden object
        /// </returns>
        public GameObject Search()
        {
            GameObject temp = HiddenObject;
            HiddenObject = null;
            return temp;
        }
    }
}
