//GameObject.cs
//Hallie Ivey (hivey@cnm.edu)
//P7 JUL2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

//GameObject is a base class for all object types and includes a decription of the item
namespace TextBasedAdventureGame
{
    public class GameObject
    {
        public virtual string Description
        { get; set; }

        
        public GameObject():this("mysterious object")
        {

        }
        public GameObject(string description)
        {
            Description = description;
            
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
