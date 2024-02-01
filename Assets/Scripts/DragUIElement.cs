using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUIElement : MonoBehaviour
{
    public Canvas canvas;
    public Transform startParent;
    public Transform parentReplacement;
    public Transform endParent;

    private void Start()
    {
        startParent = transform.parent;
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
        DragUIElement switchElement;
        if(results.Count > 2)
        {
            results[1].gameObject.TryGetComponent(out switchElement);
            if (switchElement is not null)
            {
                endParent = results[2].gameObject.transform;
                switchElement.startParent = startParent;
                switchElement.transform.position = switchElement.startParent.transform.position;
                switchElement.transform.SetParent(switchElement.startParent);
                startParent = endParent;
                transform.SetParent(startParent);
                transform.position = startParent.transform.position;
            }
        }
        else
        {
            transform.SetParent(startParent);
            transform.position = startParent.position;
        }
        
    }
}
