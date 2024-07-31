using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Audio
{
    public string audioName;
    public GameObject audioObject;
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance; //singleton
    public static AudioManager instance
    {
        get
        {
            if (!_instance)
            {
                Debug.Log("No instance!");
                var prefab = Resources.Load<GameObject>("AudioManager");
                var inScene = Instantiate(prefab);
                _instance = inScene.GetComponentInChildren<AudioManager>();
                if (!_instance) _instance = inScene.AddComponent<AudioManager>();
                DontDestroyOnLoad(_instance.transform.root.gameObject);
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<Audio> inspectorAudio;
    private Dictionary<string,GameObject> audioDict = new Dictionary<string, GameObject>();

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
        foreach (var audio in inspectorAudio)
        {
            audioDict.Add(audio.audioName, audio.audioObject);
        }
    }

    public void PlayAudio(string name, float delay = 0f)
    {
        //If it doesn't exist, return
        if (!audioDict.ContainsKey(name))
            return;
        StartCoroutine(AddAudio(name, delay));
    }

    IEnumerator AddAudio(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(audioDict[name]);
    }
}