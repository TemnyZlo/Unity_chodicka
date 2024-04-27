using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Help")]
public class Help : Action
{

    public override void RespondToInput(GameController controller, string noun)
    {
        controller.currentText.text = "Type a verb followed by a noun(e.g. \"go north\")";
        controller.currentText.text += "\nAllowed verbs: \nGo, Examine, Get, Use, Inventory, TaklTo, Say, Help";
    }

    internal override void RespondToInput(GameController gameController, object value)
    {
        throw new System.NotImplementedException();
    }
}
