using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSprite : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite onSprite;
    [SerializeField]
    private Sprite offSprite;

    public void UpdateSprite()
    {
        image.sprite = toggle.isOn ? onSprite : offSprite;
    }
}
