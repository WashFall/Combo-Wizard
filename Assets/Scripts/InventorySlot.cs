using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Ingredient ingredient;
    public Image itemImage;
    public TMP_Text amountText;

    private void Awake()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
        amountText = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (GameManager.INSTANCE.inventory.items[ingredient] > 0)
        {
            itemImage.sprite = ingredient.ingredientImage;
        }
        else
        {
            itemImage.sprite = ingredient.notAvailableImage;
        }
    }

    public void UpdateIngredient(Ingredient newIngredient)
    {
        ingredient = newIngredient;
        if (GameManager.INSTANCE.inventory.items[ingredient] > 0)
        {
            itemImage.sprite = ingredient.ingredientImage;
        }
        else
        {
            itemImage.sprite = ingredient.notAvailableImage;
        }
        amountText.text = GameManager.INSTANCE.inventory.items[ingredient].ToString();
    }

    public void UpdateAmount(int amount)
    {
        amountText.text = amount.ToString();
        if(amount <= 0)
        {
            itemImage.sprite = ingredient.notAvailableImage;
        }
        else
        {
            itemImage.sprite = ingredient.ingredientImage;
        }
    }
}
