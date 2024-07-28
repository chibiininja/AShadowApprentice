using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance; //singleton
    public static InventoryManager instance
    {
        get
        {
            if (!_instance)
            {
                Debug.Log("No instance!");
                var prefab = Resources.Load<GameObject>("FlagManager");
                var inScene = Instantiate(prefab);
                _instance = inScene.GetComponentInChildren<InventoryManager>();
                if (!_instance) _instance = inScene.AddComponent<InventoryManager>();
                DontDestroyOnLoad(_instance.transform.root.gameObject);
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<Item> items = new List<Item>();
    [SerializeField]
    private ItemDisplay[] displays;
    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private Sprite selectedSprite;
    [SerializeField]
    private GameObject itemNamePanel;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
        RefreshToggleGroup();
        SetItemName();
    }

    void RefreshToggleGroup()
    {
        foreach (var item in displays)
        {
            item.toggle.isOn = false;
            item.toggle.interactable = false;
            item.itemImage.enabled = false;
        }
        for (int i = 0; i < items.Count; i++)
        {
            displays[i].toggle.interactable = true;
            displays[i].itemImage.sprite = items[i].icon;
            displays[i].itemImage.enabled = true;
        }
    }

    public void SetItemName()
    {
        itemNamePanel.SetActive(false);
        for(int i = 0; i < displays.Length; i++) {
            if (displays[i].toggle.isOn)
            {
                itemNamePanel.GetComponentInChildren<TextMeshProUGUI>().SetText(items[i].itemName);
                itemNamePanel.SetActive(true);
                break;
            }
        }
    }

    public void Add(Item item)
    {
        items.Add(item);
        RefreshToggleGroup();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        RefreshToggleGroup();
    }

    public Sprite GetDefaultSprite()
    {
        return defaultSprite;
    }

    public Sprite GetSelectedSprite()
    {
        return selectedSprite;
    }
}