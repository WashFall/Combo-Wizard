using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> items = new Dictionary<string, int>();

    private void Start()
    {
        items.Add("bones", 0);
        items.Add("beers", 0);
        items.Add("forks", 0);
    }

    public void HandleItem(string itemName, int amount)
    {
        if(items.ContainsKey(itemName))
        {
            if(amount > 0)
            {
                items[itemName] += amount;
            }
            else if(amount < 0)
            {
                items[itemName] -= amount;
            }
        }
        else
        {
            RegisterNewItem(itemName);
        }
    }

    public void RegisterNewItem(string itemName)
    {
        items.Add(itemName, 1);
    }
}
