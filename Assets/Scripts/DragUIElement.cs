using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUIElement : MonoBehaviour
{
    public Canvas canvas;
    public Transform slotObject;
    public InventorySlot thisSlot;
    public Transform parentReplacement;

    private void Start()
    {
        slotObject = transform.parent;
        thisSlot = slotObject.GetComponent<InventorySlot>();
    }

    public void DragHandler(BaseEventData data)
    {
        transform.SetParent(parentReplacement);
        PointerEventData eventData = (PointerEventData)data;

        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            eventData.position,
            null,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void DropHandler(BaseEventData data)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        canvas.GetComponent<GraphicRaycaster>().Raycast((PointerEventData)data, results);
        InventorySlot newSlot = null;
        if(results.Count > 2)
        {
            foreach(var element in results)
            {
                element.gameObject.TryGetComponent(out newSlot);
            }

            if (newSlot is not null)
            {
                Ingredient temporary = thisSlot.ingredient;
                thisSlot.UpdateIngredient(newSlot.ingredient);
                newSlot.UpdateIngredient(temporary);
            }
        }

        transform.SetParent(slotObject);
        transform.position = slotObject.position;
    }
}
