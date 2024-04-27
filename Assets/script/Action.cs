using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public string keyword;

    public abstract void RespondToInput(GameController controller,string noun);
    internal abstract void RespondToInput(GameController gameController, object value);
}
