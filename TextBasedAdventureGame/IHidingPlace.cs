//IHidingPlace.cs
//Hallie Ivey (hivey@cnm.edu)
//P7 JUL2024
//Hallie Ivey (hivey@cnm.edu)
//JUL 2024
//P7 - Adventure Game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//IHidingPlace is an interface that is inherited by GameObjects that
//can contain another hidden GameObject
namespace TextBasedAdventureGame
{
    public interface IHidingPlace
    {
        GameObject HiddenObject
        { get; set; }

        GameObject Search();
    }
}
