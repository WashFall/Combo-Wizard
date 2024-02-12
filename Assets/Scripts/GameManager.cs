using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public PlayerManager playerManager;
    public List<Item> itemsInLevel;
    public List<Ingredient> ingredients;
    public UIManager uiManager;
    public Inventory inventory;
    public GameObject selectedItem;
    public bool gameIsPaused = false;
    public float playerMaxHealth = 100;
    public float playerHealth = 100;

    public delegate void OnItemPickUp(Ingredient item, int amount = 1);
    public OnItemPickUp onItemPickUp;

    public delegate void OnDamageTaken(float maxHealth, float playerHealth);
    public OnDamageTaken onDamageTaken;

    public delegate bool OnCastSpell();
    public OnCastSpell onCastSpell;

    public delegate void OnMovePlayer();
    public OnMovePlayer onMovePlayer;


    private void Awake()
    {
        INSTANCE = this;
        inventory = new Inventory();
        foreach (var ingredient in ingredients)
        {
            inventory.RegisterNewItem(ingredient, 0);
        }
    }

    public void AddItemToList(Item item)
    {
        itemsInLevel.Add(item);
        item.player = playerManager.transform;
    }

    public void TogglePauseGame()
    {
        gameIsPaused = !gameIsPaused;
        Time.timeScale = gameIsPaused ? 0.0f : 1.0f;
    }

    public void ItemRefill()
    {
        foreach (var item in ingredients)
        {
            onItemPickUp(item, 5);
        }
    }

    public void RemoveIngredients(Ingredient boil, Ingredient crush, Ingredient dry)
    {
        inventory.HandleItem(boil, -1);
        inventory.HandleItem(crush, -1);
        inventory.HandleItem(dry, -1);
    }
}
