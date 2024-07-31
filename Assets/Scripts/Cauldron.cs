using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField]
    private List<Item> acceptableItems = new List<Item>();
    private List<Item> currentItems = new List<Item>();
    private int counter;
    private FlagManager flagManager;

    void Start()
    {
        flagManager = FlagManager.instance;
        flagManager.SetFlag("teaFlagStart", true);
        counter = 0;
    }

    void Update()
    {
        if (flagManager.GetFlag("teaFlagStart") && !flagManager.GetFlag("teaFlagEnd"))
        {
            acceptableItems.Add(ItemDictionary.instance.GetItem("Tea Powder"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Lemon"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Vial of Water"));
            flagManager.SetFlag("teaFlagEnd", true);
        }
        if (counter == 3 && currentItems.Contains(ItemDictionary.instance.GetItem("Tea Powder")))
        {
            Debug.Log("Finished Tea Event");
            counter = 0;
            currentItems.Clear();
            DialogueManager.instance.StartDialogue(1);
            flagManager.SetFlag("ointmentFlagStart", true);
        }
        if (flagManager.GetFlag("ointmentFlagStart") && !flagManager.GetFlag("ointmentFlagEnd"))
        {
            acceptableItems.Clear();
            acceptableItems.Add(ItemDictionary.instance.GetItem("Rosemary"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Ice Cubes"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Vial of Honey"));
            flagManager.SetFlag("ointmentFlagEnd", true);
        }
        if (counter == 3 && currentItems.Contains(ItemDictionary.instance.GetItem("Vial of Honey")))
        {
            Debug.Log("Finished Ointment Event");
            counter = 0;
            currentItems.Clear();
            DialogueManager.instance.StartDialogue(2);
            flagManager.SetFlag("automatonFlagStart", true);
        }
        if (flagManager.GetFlag("automatonFlagStart") && !flagManager.GetFlag("automatonFlagEnd"))
        {
            acceptableItems.Clear();
            acceptableItems.Add(ItemDictionary.instance.GetItem("Clay"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Vial of Mercury"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Cog"));
            flagManager.SetFlag("automatonFlagEnd", true);
        }
        if (counter == 3 && currentItems.Contains(ItemDictionary.instance.GetItem("Cog")))
        {
            Debug.Log("Finished Automaton Event");
            counter = 0;
            currentItems.Clear();
            DialogueManager.instance.StartDialogue(3);
            flagManager.SetFlag("hammerFlagStart", true);
        }
        if (flagManager.GetFlag("hammerFlagStart") && !flagManager.GetFlag("hammerFlagEnd"))
        {
            acceptableItems.Clear();
            acceptableItems.Add(ItemDictionary.instance.GetItem("Metal Core"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Vial of Fire"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Pig's Blood"));
            flagManager.SetFlag("hammerFlagEnd", true);
        }
        if (counter == 3 && currentItems.Contains(ItemDictionary.instance.GetItem("Pig's Blood")))
        {
            Debug.Log("Finished Hammer Event");
            counter = 0;
            currentItems.Clear();
            DialogueManager.instance.StartDialogue(4);
            flagManager.SetFlag("pondFlagStart", true);
        }
        if (flagManager.GetFlag("pondFlagStart") && !flagManager.GetFlag("pondFlagEnd"))
        {
            acceptableItems.Clear();
            acceptableItems.Add(ItemDictionary.instance.GetItem("Worm"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Moss"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Wood"));
            flagManager.SetFlag("pondFlagEnd", true);
        }
        if (counter == 3 && currentItems.Contains(ItemDictionary.instance.GetItem("Wood")))
        {
            Debug.Log("Finished Pond Event");
            counter = 0;
            currentItems.Clear();
            DialogueManager.instance.StartDialogue(5);
            flagManager.SetFlag("loveFlagStart", true);
        }
        if (flagManager.GetFlag("loveFlagStart") && !flagManager.GetFlag("loveFlagEnd"))
        {
            acceptableItems.Clear();
            acceptableItems.Add(ItemDictionary.instance.GetItem("Dove Feathers"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Flower Petals"));
            acceptableItems.Add(ItemDictionary.instance.GetItem("Pearl"));
            flagManager.SetFlag("loveFlagEnd", true);
        }
        if (counter == 3 && currentItems.Contains(ItemDictionary.instance.GetItem("Pearl")))
        {
            Debug.Log("Finished Love Event");
            counter = 0;
            currentItems.Clear();
            DialogueManager.instance.StartDialogue(6);
        }
    }
    
    public void ValidateItem()
    {
        Item heldItem = InventoryManager.instance.CurrentSelectedItem();
        if (heldItem == null) {
            return;
        }
        if (acceptableItems.Contains(heldItem))
        {
            Debug.Log("Accepted " + heldItem.itemName + " into Cauldron");
            InventoryManager.instance.Remove(heldItem);
            currentItems.Add(heldItem);
            counter++;
        }
    }
}
