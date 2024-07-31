using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueNode : MonoBehaviour
{
    [Serializable]
    public class AudioPair
    {
        public string name;
        public float delay;
    }

    [SerializeField]
    private string speaker;
    [SerializeField]
    private string text;
    [SerializeField]
    private Sprite leftCharacter;
    [SerializeField]
    private Sprite rightCharacter;
    [SerializeField]
    private DialogueNode destination;
    [SerializeField]
    private List<AudioPair> audioList;

    void OnEnable()
    {
        DialogueManager.instance.SetNameField(speaker);
        DialogueManager.instance.SetLeftCharacter(leftCharacter);
        DialogueManager.instance.SetRightCharacter(rightCharacter);
        StartCoroutine(TypeSentence(text));
        PlayAudio();
    }

    IEnumerator TypeSentence (string text)
    {
        string builtString = "";
        DialogueManager.instance.SetTextField(builtString);
        foreach (char letter in text.ToCharArray())
        {
            builtString += letter;
            DialogueManager.instance.SetTextField(builtString);
            yield return null;
        }
    }

    void PlayAudio()
    {
        foreach (var audioObject in audioList)
        {
            AudioManager.instance.PlayAudio(audioObject.name, audioObject.delay);
        }
    }

    public DialogueNode NextDialogue()
    {
        this.gameObject.SetActive(false);
        StopAllCoroutines();
        if (destination == null)
        {
            DialogueManager.instance.SetDialogueScreen(false);
            DialogueManager.instance.SetGameplayScreen(true);
            return null;
        }
        else
        {
            destination.gameObject.SetActive(true);
            return destination;
        }
    }
}
