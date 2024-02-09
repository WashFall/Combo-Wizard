using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [HideInInspector]
    public GameObject player;
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


    private void Awake()
    {
        INSTANCE = this;
        player = GameObject.Find("Player");
        inventory = new Inventory();
        foreach (var ingredient in ingredients)
        {
            inventory.RegisterNewItem(ingredient, 0);
        }
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

    public void TakeDamage(float damage)
    {
        if(playerHealth > 0)
        {
            playerHealth -= damage;
        }
    }
}
