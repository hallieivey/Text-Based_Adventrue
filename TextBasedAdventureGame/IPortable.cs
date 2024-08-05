//IPortable.cs
//Hallie Ivey (hivey@cnm.edu)
//P7 JUL2024
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//IPortable is a interface that is utilized by GameObjects that may be picked up by a player
//HI- added the Price field 
namespace TextBasedAdventureGame
{
    public interface IPortable
    {
        int Size
        { get; set; }
        
        decimal Price
        {  get; set; }
    }
}
