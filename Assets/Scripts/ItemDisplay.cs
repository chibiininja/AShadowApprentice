using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Toggle toggle;
    public Image itemImage;
    [SerializeField]
    private Image itemBoxImage;

    public void UpdateSprite()
    {
        itemBoxImage.color = toggle.isOn ? Color.gray : Color.white;
    }
}
