// TravelOption
// Programer: Rob Garner (rgarner7@cnm.edu)
// Date: 25 May 2016
// Represents a travel option.

//Edited by Hallie Ivey (hivey@cnm.edu)
//P7 JUL 2024
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Class that represents the game. 
    /// Has a map and location of player.
    /// </summary>
    class Map
    {
        /// <summary>
        /// List of map locations.
        /// </summary>
        public List<MapLocation> Locations { get; set; }

        /// <summary>
        /// Player's location.
        /// </summary>
        //public MapLocation PlayerLocation { get; set; }

        /// <summary>
        /// Constructor that creates the game map.
        /// </summary>
        public Map()
        {
            //TODO: change map locations and add items

            //Create map locations first
            Locations = new List<MapLocation>();           
            Locations.Add(new MapLocation("You are standing on the front porch of the house."));
            Locations.Add(new MapLocation("You are in the dinning room"));
            Locations.Add(new MapLocation("You are in the kitchen"));
            Locations.Add(new MapLocation("You are in the art studio"));
            Locations.Add(new MapLocation("You are in the drawing room"));
            Locations.Add(new MapLocation("You are in the guest bathroom"));
            Locations.Add(new MapLocation("You are in the master bedroom"));
            Locations.Add(new MapLocation("You are in the master bathroom"));
            Locations.Add(new MapLocation("You are standing in front of the closet"));
            Locations.Add(new MapLocation("exit"));

            #region Travel Options
            //Front Porch
            Locations[0].TravelOptions.Add(new TravelOption("The door to the house in in front of you",Locations[1]));
            Locations[0].TravelOptions.Add(new TravelOption("Escape and exit with your riches", Locations[9]));

            //Dinning Room
            Locations[1].TravelOptions.Add(new TravelOption("The door out towards the patio is south of you", Locations[0]));            
            Locations[1].TravelOptions.Add(new TravelOption("The kitchen is north of you", Locations[2]));            
            Locations[1].TravelOptions.Add(new TravelOption("The art studio is north east of you", Locations[3]));
            Locations[1].TravelOptions.Add(new TravelOption("The drawing room is east of you", Locations[4]));
            Locations[1].TravelOptions.Add(new TravelOption("The guest bathroom is west of you", Locations[5]));
            Locations[1].TravelOptions.Add(new TravelOption("The master bedroom is southwest of you", Locations[6]));

            //Kitchen
            Locations[2].TravelOptions.Add(new TravelOption("The way to the dinning room is behind you", Locations[1]));

            //Art Studio
            Locations[3].TravelOptions.Add(new TravelOption("The door goes back into the dinning room ", Locations[1]));
            
            //Drawing Room
            Locations[4].TravelOptions.Add(new TravelOption("The way to the dinning room is behind you", Locations[1]));

            //Guest Bathroom
            Locations[5].TravelOptions.Add(new TravelOption("The door goes back into the dinning room", Locations[1]));
            
            //Master Bedroom
            Locations[6].TravelOptions.Add(new TravelOption("The door behind you goes back into the dinning room", Locations[1]));
            Locations[6].TravelOptions.Add(new TravelOption("An old closet sits in the corner of the room", Locations[8]));
            Locations[6].TravelOptions.Add(new TravelOption("The door to the master bathroom is to the north ", Locations[7]));

            //Master Bathroom
            Locations[7].TravelOptions.Add(new TravelOption("The door goes back into the master bedroom", Locations[6]));

            //Closet
            Locations[8].TravelOptions.Add(new TravelOption("Behind you is the master bedroom", Locations[6]));
            
            #endregion

            #region Items
            //Patio
            HidingPlace fakeRock = new HidingPlace("fake rock");
            fakeRock.HiddenObject = new InventoryItem("silver key", 1, 0.40M);
            Locations[0].Items.Add(fakeRock);

            //Dinning Room
            Locations[1].Items.Add(new InventoryItem("box of silverware", 3, 200.00M));

            //Kitchen
            Locations[2].Items.Add(new InventoryItem("stale cookies", 2, 3.00M));

            //Art Studio
            Locations[3].Items.Add(new InventoryItem("painting of an ugly dog", 3, 20.00M));
            PortableHidingPlace pot = new PortableHidingPlace("brown pot", 3,
                new InventoryItem("emerald ring", 1, 1000.00M), 70.00M);
            Locations[3].Items.Add(pot);

            //Drawing Room
            Locations[4].Items.Add(new InventoryItem("lace gloves", 1, 50.00M));
            HidingPlace portrait = new HidingPlace("large portrait of grammy",
                new InventoryItem("rusty key", 1, 0.01M));
            Locations[4].Items.Add(portrait);
            //Guest Bathroom
            GameObject sconce = new GameObject("brass sconce");
            Locations[5].Items.Add(sconce);

            //Master Bedroom
            PortableHidingPlace box = new PortableHidingPlace("jewelry box", 3, 
                new InventoryItem("tangled necklace", 1, 20.00M), 500.00M);
            Locations[6].Items.Add(box);

            //Closet
            Locations[8].Items.Add(new InventoryItem("emerald tiara", 2, 5000.00M));
            
            #endregion
            
        }

    }
}
