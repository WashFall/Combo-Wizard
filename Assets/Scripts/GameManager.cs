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
    public GameObject selectedItem;
    public bool gameIsPaused = false;

    public delegate void OnItemPickUp(string itemName, int amount = 1);
    public OnItemPickUp onItemPickUp;

    private void Awake()
    {
        INSTANCE = this;
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        AssignListeners();
    }

    private void AssignListeners()
    {
        onItemPickUp += inventory.HandleItem;
    }

    public void AddItemToList(Item item)
    {
        itemsInLevel.Add(item);
        item.player = player.transform;
    }

    public void TogglePauseGame()
    {
        gameIsPaused = !gameIsPaused;
        Time.timeScale = gameIsPaused ? 0.0f : 1.0f;
    }
}
