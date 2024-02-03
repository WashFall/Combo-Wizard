using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [HideInInspector]
    public GameObject player;
    public Inventory inventory = new Inventory();
    public List<Item> itemsInLevel;
    public List<Ingredient> ingredients;
    public UIManager uiManager;
    public GameObject selectedItem;
    public bool gameIsPaused = false;

    public delegate void OnItemPickUp(Ingredient item, int amount = 1);
    public OnItemPickUp onItemPickUp;

    private void Awake()
    {
        INSTANCE = this;
        player = GameObject.Find("Player");
        foreach (var ingredient in ingredients)
        {
            inventory.RegisterNewItem(ingredient, 0);
        }
    }

    private void Start()
    {
        AssignListeners();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach(var item in ingredients)
            {
                onItemPickUp(item, 5);
            }
        }
    }

    private void AssignListeners()
    {
        onItemPickUp += inventory.HandleItem;
        onItemPickUp += uiManager.UpdateIngredientAmount;
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
