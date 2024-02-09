using System.Collections.Generic;

public class Inventory
{
    public Dictionary<Ingredient, int> items = new Dictionary<Ingredient, int>();

    public void HandleItem(Ingredient item, int amount)
    {
        if(items.ContainsKey(item))
        {
            if(amount > 0)
            {
                items[item] += amount;
            }
            else if(amount < 0)
            {
                if (items[item] + amount <= 0)
                {
                    items[item] = 0;
                    return;
                }
                items[item] += amount;
            }
        }
        else
        {
            RegisterNewItem(item, 1);
        }
    }

    public void RegisterNewItem(Ingredient item, int amount)
    {
        items.Add(item, amount);
    }

    public Inventory()
    {
        GameManager.INSTANCE.onItemPickUp += HandleItem;
    }
}
