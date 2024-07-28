using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Flag
{
    public string flagName;
    public bool value;
}

public class FlagManager : MonoBehaviour
{
    private static FlagManager _instance; //singleton
    public static FlagManager instance
    {
        get
        {
            if (!_instance)
            {
                Debug.Log("No instance!");
                var prefab = Resources.Load<GameObject>("FlagManager");
                var inScene = Instantiate(prefab);
                _instance = inScene.GetComponentInChildren<FlagManager>();
                if (!_instance) _instance = inScene.AddComponent<FlagManager>();
                DontDestroyOnLoad(_instance.transform.root.gameObject);
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<Flag> inspectorFlags;
    private Dictionary<string,bool> flags = new Dictionary<string, bool>();

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
        foreach (var flag in inspectorFlags)
        {
            flags.Add(flag.flagName, flag.value);
        }
    }
}