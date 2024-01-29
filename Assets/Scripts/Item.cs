using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    [HideInInspector]
    public Transform player;
    public bool available = true;

    private float pickUpDistance = 2f;

    private void Start()
    {
        GameManager.INSTANCE.AddItemToList(this);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, gameObject.transform.position) < pickUpDistance)
        {
            if(available && GameManager.INSTANCE.selectedItem == gameObject)
            {
                GameManager.INSTANCE.OnItemPickUp(itemName);
                GameManager.INSTANCE.itemsInLevel.Remove(this);
                Destroy(gameObject);
            }
        }
    }

    // If player is close enough and the item is available, pick it up on mouse click
    private void OnMouseDown()
    {
        GameManager.INSTANCE.selectedItem = gameObject;
    }

    // Call this method when the item is not pickupable before a spell is casted for example
    public void MakeAvailable()
    {
        available = true;
    }
}
