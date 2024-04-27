using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Examine")]
abstract class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    
        {
            // check items in room 
            if (CheckItems(controller, controller.player.currentLocation.items, noun))
                return;

            // chech items in inventory

            if (CheckItems(controller, controller.player.inventory, noun))
                return;

            controller.currentText.text = "You can´t see a " + noun;
        }

        private bool CheckItems(GameController controller, List<Item> items, string noun)
        {
            foreach (Item item in items)
            {
                if (item.itemName == noun)
                {
                    if (item.InteractWith(controller, "examine"))
                        return true;
                    controller.currentText.text = "You see " + item.describtion;
                    return true;
                }

            }
            return false;
        }
    

 
}
