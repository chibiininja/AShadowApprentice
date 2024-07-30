using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance; //singleton
    public static DialogueManager instance
    {
        get
        {
            if (!_instance)
            {
                Debug.Log("No instance!");
                var prefab = Resources.Load<GameObject>("DialogueManager");
                var inScene = Instantiate(prefab);
                _instance = inScene.GetComponentInChildren<DialogueManager>();
                if (!_instance) _instance = inScene.AddComponent<DialogueManager>();
                DontDestroyOnLoad(_instance.transform.root.gameObject);
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject[] dialogue;
    [SerializeField]
    private GameObject dialogueScreen;
    [SerializeField]
    private GameObject gameplayScreen;
    [SerializeField]
    private Image leftCharacter;
    [SerializeField]
    private Image rightCharacter;
    [SerializeField]
    private TextMeshProUGUI nameField;
    [SerializeField]
    private TextMeshProUGUI textField;

    private DialogueNode currentDialogue;

    public void StartDialogue(int index)
    {
        if (index < 0 || index >= dialogue.Length)
            return;
        gameplayScreen.SetActive(false);
        currentDialogue = dialogue[index].GetComponent<DialogueNode>();
        dialogue[index].gameObject.SetActive(true);
        dialogueScreen.SetActive(true);
    }

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
    }

    public void SetDialogueScreen(bool active)
    {
        dialogueScreen.SetActive(active);
    }

    public void SetGameplayScreen(bool active)
    {
        gameplayScreen.SetActive(active);
    }

    public void SetLeftCharacter(Sprite sprite)
    {
        if (sprite == null)
            return;
        leftCharacter.sprite = sprite;
    }

    public void SetRightCharacter(Sprite sprite)
    {
        if (sprite == null)
            return;
        rightCharacter.sprite = sprite;
    }

    public void SetNameField(string speaker)
    {
        nameField.SetText(speaker);
    }

    public void SetTextField(string text)
    {
        textField.SetText(text);
    }

    public void NextDialogue()
    {
        if (!currentDialogue)
            return;
        currentDialogue = currentDialogue.NextDialogue();
    }
}
