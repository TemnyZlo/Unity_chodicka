using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Interaction
{
    public Action action;

    [TextArea]
    public string response;

    public List<Item> itemToEnable = new List<Item>();
    public List<Item> itemToDisable = new List<Item>();

    public List<Connection> connectionsToEnable = new List<Connection>();
    public List<Connection> connectionsToDisable = new List<Connection>();
    public string actionKeyword;
}