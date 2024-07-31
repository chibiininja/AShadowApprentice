using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEnabler : MonoBehaviour
{
    [SerializeField]
    private GameObject inactiveObject;

    void OnEnable()
    {
        inactiveObject.SetActive(true);
    }
}
