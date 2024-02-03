using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public Ingredient ingredient = null;
    public Image slotImage;
    public TMP_Text slotText;

    private void Start()
    {
        slotImage = transform.GetChild(0).GetComponent<Image>();
        slotText = transform.GetChild(1).GetComponent<TMP_Text>();
        slotImage.preserveAspect = true;
    }

    public void UpdateIngredient(Ingredient newIngredient)
    {
        ingredient = newIngredient;
        if (GameManager.INSTANCE.inventory.items[ingredient] > 0)
        {
            slotImage.sprite = ingredient.ingredientImage;
        }
        else
        {
            slotImage.sprite = ingredient.notAvailableImage;
        }
        slotText.text = GameManager.INSTANCE.inventory.items[ingredient].ToString();
    }

    public void UpdateAmount(int amount)
    {
        slotText.text = amount.ToString();
        if (amount <= 0)
        {
            slotImage.sprite = ingredient.notAvailableImage;
        }
        else
        {
            slotImage.sprite = ingredient.ingredientImage;
        }
    }
}
