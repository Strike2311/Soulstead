using UnityEngine;

[CreateAssetMenu(fileName = "InventorySlot", menuName = "Scriptable Objects/InventorySlot")]
[System.Serializable]
public class InventorySlot : ScriptableObject
{
    public InventoryItem item;
    public int quantity;
    public bool IsEmpty => item == null;
}
