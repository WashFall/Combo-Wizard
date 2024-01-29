using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [HideInInspector]
    public GameObject player;
    public Inventory inventory;
    public List<Item> itemsInLevel;
    public UIManager uiManager;

    private void Awake()
    {
        INSTANCE = this;
        player = GameObject.Find("Player");
    }

    public void AddItemToList(Item item)
    {
        itemsInLevel.Add(item);
        item.player = player.transform;
    }

    public void OnItemPickUp(string itemName)
    {
        inventory.onItemPickUp(itemName);
        uiManager.UpdateText(itemName, inventory.items[itemName]);
    }
}
