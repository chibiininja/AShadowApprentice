using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private List<Sprite> frames;

    void OnEnable()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        foreach (var frame in frames)
        {
            image.sprite = frame;
            yield return new WaitForSeconds(0.1f);
        }
        DialogueManager.instance.StartDialogue(0);
        this.gameObject.SetActive(false);
    }
}
