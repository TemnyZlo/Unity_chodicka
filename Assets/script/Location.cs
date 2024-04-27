using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Location : MonoBehaviour
{
    public string locationName;

  
    

    [TextArea]
    public string describtion;
    // Start is called before the first frame update
    public Connection[] connections;

    public List<Item> items = new List<Item>();
    private bool first;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public string GetItemsText()
    {
        if (items.Count == 0) return "";

        string result = "You see  ";

        bool firts = true;

        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!firts) result += " and ";
                result += item.describtion;
                first = false;
            }
           
        }

        result += "\n";
        return result;
    }
    public string GetConnectionText() 
    {
        string result = "";
        foreach(Connection connection in connections) 
        {
            if (connection.connectionEnabled)
                result += connection.describtion + "\n";
        }   
        return result;
    }


    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections) 
        {
            if (connection.connectionName.ToLower().Contains(connectionNoun.ToLower())) 
                return connection;
        }
        return null;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {

            if (item == itemToCheck && item.itemEnabled)
                return true;

        }
        return false;
    }
}
