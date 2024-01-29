using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> items = new Dictionary<string, int>();

    public delegate void OnItemPickUp(string itemName);
    public OnItemPickUp onItemPickUp;

    private void Start()
    {
        onItemPickUp += ItemPickUp;
        items.Add("bones", 0);
        items.Add("beers", 0);
        items.Add("forks", 0);
    }

    public void ItemPickUp(string itemName)
    {
        if(items.ContainsKey(itemName))
        {
            items[itemName]++;
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

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        OnItemPickUp("bones");
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        OnItemPickUp("beers");
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        OnItemPickUp("forks");
    //    }
    //}
}
