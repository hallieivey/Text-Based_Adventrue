// TravelWindow
// Programer: Rob Garner (rgarner7@cnm.edu)
// Date: 25 May 2016
// User interface that provides user capability to travel

//Edited by Hallie Ivey (hivey@cnm.edu)
//JUL 2024
//P7 - Adventure Game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Window that shows player where they are and provides capability to move from location to location in the map.
    /// </summary>
    public partial class TravelWindow : Window
    {
        /// <summary>
        /// Game object that has map
        /// </summary>
        Map game;
       
        Player player;

        /// <summary>
        /// Initialize the form, the game and call update display to start the form.
        /// </summary>
        public TravelWindow()
        {
            InitializeComponent();

            MessageBox.Show("The old bat is finally dead! You’ve been waiting for your sad bitter " +
                "(and filthy rich) grandmother to kick the bucket and the day is now upon you. " +
                "Unfortunately, you are not anywhere in her will... but no worries! You managed to " +
                "sneak into her house before your money-hungry cousins and aunts to grab the most valuable " +
                "items you could carry. You only have so much pocket space so choose wisely, and don’t " +
                "forget to search certain un-assuming items for goodies that wrinkly old prune tried to hide away.", "The story" );
            game = new Map();
            player = new Player(game.Locations[0]);
            UpdateDisplay();
        }

        /// <summary>
        /// Tells the player where they are.
        /// </summary>
        //private void DisplayLocation()
        //{
        //    txbLocationDescription.Text = player.Location.Description;
        //    lbTravelOptions.ItemsSource = player.Inventory;
        //}

        /// <summary>
        /// Double click a travel option to move to a new location on the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTraveOptions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TravelOption to = (TravelOption)lbTravelOptions.SelectedItem;
            //Check in case user accidentally double clicks without selecting 
            if (to != null)
            {
                //If player is trying to get through front door
                if (to.Description == "The door to the house in in front of you")
                {
                    bool hasKey = false;
                    foreach (GameObject item in player.Inventory)
                    {
                        if (item.Description == "silver key")
                        {
                            hasKey = true;
                        }
                    }
                    if (hasKey)
                    {
                        player.Location = to.Location;
                    }
                    else
                    {
                        lbGameStatus.Items.Insert(0, "Front Door is locked");
                    }

                }
                //if player is trying to got to the closet
                else if (to.Description == "An old closet sits in the corner of the room")
                {
                    bool hasKey = false;
                    foreach (GameObject item in player.Inventory)
                    {
                        if (item.Description == "rusty key")
                        {
                            hasKey = true;
                        }
                    }
                    if (hasKey)
                    {
                        player.Location = to.Location;
                    }
                    else
                    {
                        lbGameStatus.Items.Insert(0, "Closet Door is locked");
                    }

                }
                else
                {
                    player.Location = to.Location;
                }

            }
            //check if player has "exited"
            if(player.Location.Description == "exit")
            {
                txbLocationDescription.Text =
                    "You escaped with " + player.TotalPrice() + " of goods!";
                
            }
            else
            {
                UpdateDisplay();
            }

        }

        //Search button will look at selected items and show any hidden item
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(lbItemsInRoom.SelectedItem is IHidingPlace)
            {
                //if true reveal item
                IHidingPlace tempHidingPlace = (IHidingPlace)lbItemsInRoom.SelectedItem;
                GameObject foundItem = tempHidingPlace.Search();
                if(foundItem !=null)
                {
                    player.Location.Items.Add(foundItem);
                    UpdateDisplay();
                }
               
            }
            else
            {
                //object is not a hiding place 
                lbGameStatus.Items.Insert ( 0,"Object is not hiding anything");
                
            }
        }
        //Take will put item in player 
        private void btnTake_Click(object sender, RoutedEventArgs e)
        {
            
            if(lbItemsInRoom.SelectedItem is IPortable)
            {
                GameObject tempItem = (GameObject)lbItemsInRoom.SelectedItem;
                bool canPickUp = player.AddInventoryItem((IPortable)tempItem);
                if(!canPickUp)
                {
                    lbGameStatus.Items.Insert(0, "Your pockets are full!");
                    
                }
                else
                {
                    player.Location.Items.Remove(tempItem);
                }
                UpdateDisplay();
                

            }
            else
            {
                lbGameStatus.Items.Insert(0, "You can't pick up that item");
            }
            

        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            player.RemoveInventoryItem((IPortable)lbPlayerInventory.SelectedItem);
            player.Location.Items.Add((GameObject)lbPlayerInventory.SelectedItem);
            UpdateDisplay ();
            
        }

       //Updates text box and list box with current information
        public void UpdateDisplay()
        {
            txbLocationDescription.Text = player.Location.ToString();
            lbTravelOptions.ItemsSource = player.Location.TravelOptions;
            lbTravelOptions.Items.Refresh();

            lbPlayerInventory.ItemsSource = player.Inventory;
            lbPlayerInventory.Items.Refresh();

            lbItemsInRoom.ItemsSource = player.Location.Items;
            lbItemsInRoom.Items.Refresh();

        }
    }
}
