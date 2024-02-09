using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<InventorySlot> inventorySlots;
    public SpellSlot boil, crush, dry;
    public Transform healthDisplay;
    public Image healthBar;
    private int boilIndex = -3, crushIndex = -2, dryIndex = -1;

    private void Start()
    {
        foreach (Transform slot in inventoryPanel.transform)
        {
            inventorySlots.Add(slot.GetComponent<InventorySlot>());
        }
        inventoryPanel.SetActive(false);
        GameManager.INSTANCE.onItemPickUp += UpdateIngredientAmount;
        GameManager.INSTANCE.onDamageTaken += UpdateHealth;
    }

    public void UpdateHealth(float maxHealth, float playerHealth)
    {
        healthBar.fillAmount = (1 / maxHealth) * playerHealth;
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void SubmitSpell()
    {
        boilIndex = -3;
        crushIndex = -2;
        dryIndex = -1;
    }

    public void ShiftSlot(string slot)
    {
        switch (slot)
        {
            case "boil":
                boilIndex += 3;
                if (boilIndex > 6)
                {
                    boilIndex = 0;
                }
                boil.UpdateIngredient(inventorySlots[boilIndex].ingredient);
                break;
            case "crush":
                crushIndex += 3;
                if (crushIndex > 7)
                {
                    crushIndex = 1;
                }
                crush.UpdateIngredient(inventorySlots[crushIndex].ingredient);
                break;
            case "dry":
                dryIndex += 3;
                if (dryIndex > 8)
                {
                    dryIndex = 2;
                }
                dry.UpdateIngredient(inventorySlots[dryIndex].ingredient);
                break;
        }
        
    }

    public void UpdateIngredientAmount(Ingredient ingredient, int amount)
    {
        foreach(var item in inventorySlots)
        {
            if(item.ingredient == ingredient)
            {
                item.UpdateAmount(GameManager.INSTANCE.inventory.items[ingredient]); 
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