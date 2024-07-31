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
    private RectTransform inventoryArea;
    [SerializeField]
    private Toggle inventoryButton;
    [SerializeField]
    private GameObject itemNamePanel;
    [SerializeField]
    private ToggleGroup inventoryGroup;
    private List<Item> previousItems = new List<Item>();

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
        TextMeshProUGUI itemText = itemNamePanel.GetComponentInChildren<TextMeshProUGUI>();
        itemText.SetText("");
        for (int i = 0; i < displays.Length; i++) {
            if (displays[i].toggle.isOn)
            {
                itemText.SetText(items[i].itemName);
                itemNamePanel.SetActive(true);
                break;
            }
        }
    }

    public void UpdateInventoryArea()
    {
        Vector3 position = inventoryButton.isOn ? new Vector3(0, 0, 0) : new Vector3(0, 140, 0);
        inventoryArea.anchoredPosition = position;
    }

    public void Add(Item item)
    {
        if (previousItems.Contains(item))
        {
            return;
        }
        AudioManager.instance.PlayAudio("pickup");
        AudioManager.instance.PlayAudio(item.addNoise);
        items.Add(item);
        RefreshToggleGroup();
        previousItems.Add(item);
    }

    public void Remove(Item item)
    {
        AudioManager.instance.PlayAudio(item.removeNoise);
        items.Remove(item);
        RefreshToggleGroup();
    }

    public Item CurrentSelectedItem()
    {
        if (!inventoryGroup.AnyTogglesOn()) 
            return null;
        
        for (int i = 0;i < displays.Length; i++) {
            if (displays[i].toggle.isOn)
            {
                return items[i];
            }
        }
        return null;
    }
}