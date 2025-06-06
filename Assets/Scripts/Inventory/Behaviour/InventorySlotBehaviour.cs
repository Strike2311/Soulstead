using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotBehaviour : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItemBehaviour inventoryItem = dropped.GetComponent<InventoryItemBehaviour>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
