using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "You have nothing";
            return;
        }

        string result = "You have";


        bool firts = true;
        foreach (Item item in controller.player.inventory)
        {
            if (firts)
            {
                result += ", a " + item.itemName;
            }
            else
            {
                result += "and a " + item.itemName;
            }
            firts = false;
            
        }
        controller.currentText.text = result;
    }


    internal override void RespondToInput(GameController gameController, object value)
    {
        throw new System.NotImplementedException();
    }
}
