using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    private Queue<Phrase> phrases;
    private GameObject interfaceToShow;
    public GameObject dialogueUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    void Start()
    {
        phrases = new Queue<Phrase>();
    }

    private void Update()
    {
        if (inputManager.UI.Click.WasReleasedThisFrame() && dialogueUI.activeSelf)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        inputManager.SwitchActionMap();
        Time.timeScale = .0f;
        dialogueUI.SetActive(true);
        interfaceToShow = dialogue.interfaceToShow;

        phrases.Clear();

        foreach (Phrase phrase in dialogue.phrases)
        {
            phrases.Enqueue(phrase);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (phrases.Count == 0)
        {
            EndDialogue();
            return;
        }

        Phrase phrase = phrases.Dequeue();
        StopAllCoroutines();
        nameText.text = phrase.name;
        StartCoroutine(TypeSentence(phrase.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = string.Empty;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        inputManager.SwitchActionMap();
        Time.timeScale = 1.0f;
        dialogueUI.SetActive(false);
        if (interfaceToShow != null)
        {
            interfaceToShow.SetActive(true);
        }
    }
}
