using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Location currentLocation;
    
    public List<Item> inventory = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        
    }


    public bool ChangeLocation(GameController controller,string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if (connection != null) 
        {
            if (connection.connectionEnabled) 
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
            return true;
        
        if(HasItem(item.targetItem))
            return true;

        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory) 
        {
        
            if (item == itemToCheck && item.itemEnabled)
                return true;
        
        }
        return false;
    }
}
