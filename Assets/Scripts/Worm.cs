using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worm : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private int counter = 0;
    private bool acquireWorm;

    void Update()
    {
        if (counter >= 9) {
            image.color = new Color(1f, 1f, 1f, 1f);
            if (!acquireWorm)
            {
                InventoryManager.instance.Add(ItemDictionary.instance.GetItem("Worm"));
                acquireWorm = true;
            }
        }
    }

    public void Increment()
    {
        counter++;
    }
}
