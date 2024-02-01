using UnityEngine;
using static GameManager;

public class Item : MonoBehaviour
{
    public string itemName;
    [HideInInspector]
    public Transform player;
    public bool available = true;

    private float pickUpDistance = 2f;

    private void Start()
    {
        INSTANCE.AddItemToList(this);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, gameObject.transform.position) < pickUpDistance)
        {
            if(available && INSTANCE.selectedItem == gameObject)
            {
                INSTANCE.onItemPickUp(itemName);
                INSTANCE.itemsInLevel.Remove(this);
                Destroy(gameObject);
            }
        }
    }

    // If player is close enough and the item is available, pick it up on mouse click
    private void OnMouseDown()
    {
        if(INSTANCE.gameIsPaused)
        {
            return;
        }
        INSTANCE.selectedItem = gameObject;
    }

    // Call this method when the item is not pickupable before a spell is casted for example
    public void MakeAvailable()
    {
        available = true;
    }
}
