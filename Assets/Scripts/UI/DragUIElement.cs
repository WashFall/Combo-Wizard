using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*
 * This class is to be put on objects that can be dragged around with the mouse.
 * Specifically inventory objects at the moment, but this may change.
 * 
 * Make sure that these objects lies further down the hierarchy than all other UI elements
 * (further down means they render later), because otherwise the "DropHandler" method won't run,
 * causing the objects to stick to the other UI elements instead of returning to their slots.
 */

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
