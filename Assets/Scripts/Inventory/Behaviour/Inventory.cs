using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size = 20;
    public List<InventorySlot> slots = new List<InventorySlot>();
    void Awake()
    {
        for (int i = 0; i < size; i++)
            slots.Add(new InventorySlot());
    }   

    public bool AddItem(InventoryItem item, int amount = 1)
    {
        if (item.stackable)
        {
            foreach (var slot in slots)
            {
                if (slot.item == item && slot.quantity < item.maxStack)
                {
                    int spaceLeft = item.maxStack - slot.quantity;
                    int addAmount = Mathf.Min(spaceLeft, amount);
                    slot.quantity += addAmount;
                    amount -= addAmount;

                    if (amount <= 0) return true;
                }
            }
        }

        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.item = item;
                slot.quantity = amount;
                return true;
            }
        }

        return false;
    }
}
