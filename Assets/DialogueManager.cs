using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public bool QuieroQueSeCierre; 

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string setence in dialogue.sentences)
        {
            sentences.Enqueue(setence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        if (QuieroQueSeCierre)
        {
            Application.Quit();
        }
    }

    


}
