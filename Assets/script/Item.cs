using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public string itemName;

    [TextArea]
    public string describtion;

    public bool playerCanTake;

    public bool itemEnabled = true;

    public Item targetItem = null;



    public Interaction[] interactions;
 
    public bool InteractWith(GameController controller, string actionKeyword)
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.actionKeyword == actionKeyword)
            {
                foreach(Item disableItem in interaction.itemToDisable)
                    disableItem.itemEnabled = false;

                foreach (Item enableItem in interaction.itemToEnable)
                    enableItem.itemEnabled = true;

                foreach (Connection disableConnection in interaction.connectionsToDisable)
                    disableConnection.connectionEnabled = false;

                foreach (Connection enableConnection in interaction.connectionsToEnable)
                    enableConnection.connectionEnabled = true;

                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);

                return true;
            }
        }
        return false;
    }

    internal bool InteractWith(string v)
    {
        throw new NotImplementedException();
    }
}
