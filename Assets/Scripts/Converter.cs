using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    [SerializeField]
    private Item acceptableItem;
    [SerializeField]
    private Item returnedItem;
    
    public void ValidateItem()
    {
        Item heldItem = InventoryManager.instance.CurrentSelectedItem();
        if (heldItem == null) {
            return;
        }
        if (heldItem == acceptableItem)
        {
            Debug.Log("Accepted " + heldItem.itemName + " into Mortar and Pestle");
            InventoryManager.instance.Remove(heldItem);
            InventoryManager.instance.Add(returnedItem);
        }
    }
}
