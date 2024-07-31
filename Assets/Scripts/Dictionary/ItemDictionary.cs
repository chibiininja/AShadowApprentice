using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary: MonoBehaviour
{
    private static ItemDictionary _instance; //singleton
    public static ItemDictionary instance
    {
        get
        {
            if (!_instance)
            {
                Debug.Log("No instance!");
                var prefab = Resources.Load<GameObject>("ItemDictionary");
                var inScene = Instantiate(prefab);
                _instance = inScene.GetComponentInChildren<ItemDictionary>();
                if (!_instance) _instance = inScene.AddComponent<ItemDictionary>();
                DontDestroyOnLoad(_instance.transform.root.gameObject);
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<Item> items;
    private Dictionary<string, Item> itemDict = new Dictionary<string, Item>();

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
        FillDictionary();
    }

    void FillDictionary()
    {
        foreach (var item in items)
        {
            itemDict.Add(item.itemName, item);
        }
    }

    public Item GetItem(string name)
    {
        return itemDict[name];
    }
}