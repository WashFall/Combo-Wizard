using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<Transform> inventorySlots;
    public SpellSlot boil, crush, dry;
    private int boilIndex = -3, crushIndex = -2, dryIndex = -1;

    private void Start()
    {
        foreach (Transform slot in inventoryPanel.transform)
        {
            inventorySlots.Add(slot);
        }
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            GameManager.INSTANCE.TogglePauseGame();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            boilIndex += 3;
            if(boilIndex > 6)
            {
                boilIndex = 0;
            }
            boil.UpdateIngredient(inventorySlots[boilIndex].GetComponent<InventorySlot>().ingredient);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            crushIndex += 3;
            if(crushIndex > 7)
            {
                crushIndex = 1;
            }
            crush.UpdateIngredient(inventorySlots[crushIndex].GetComponent<InventorySlot>().ingredient);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dryIndex += 3;
            if(dryIndex > 8)
            {
                dryIndex = 2;
            }
            dry.UpdateIngredient(inventorySlots[dryIndex].GetComponent<InventorySlot>().ingredient);
        }

        if (Input.GetMouseButtonDown(1))
        {
            boilIndex = -3;
            crushIndex = -2;
            dryIndex = -1;
            GameManager.INSTANCE.onItemPickUp(boil.ingredient, -1);
            GameManager.INSTANCE.onItemPickUp(crush.ingredient, -1);
            GameManager.INSTANCE.onItemPickUp(dry.ingredient, -1);
        }
    }

    public void UpdateIngredientAmount(Ingredient ingredient, int amount)
    {
        foreach(var item in inventorySlots)
        {
            if(item.GetComponent<InventorySlot>().ingredient == ingredient)
            {
                item.GetComponent<InventorySlot>().UpdateAmount(GameManager.INSTANCE.inventory.items[ingredient]); 
                break;
            }
        }

        if(boil.ingredient == ingredient)
        {
            boil.UpdateAmount(GameManager.INSTANCE.inventory.items[ingredient]);
        }
        if(crush.ingredient == ingredient)
        {
            crush.UpdateAmount(GameManager.INSTANCE.inventory.items[ingredient]);
        }
        if(dry.ingredient == ingredient)
        {
            dry.UpdateAmount(GameManager.INSTANCE.inventory.items[ingredient]);
        }
    }
}