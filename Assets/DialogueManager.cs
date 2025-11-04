using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] float typingSpeed;

    [TextArea(3, 10)]
    [SerializeField] string[] dialoguesExamples;

    int index = 0;

    string fullText;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && index < dialoguesExamples.Length)
        {
            PlayDialogue(dialoguesExamples[index]);
            index++;

            if (index >= dialoguesExamples.Length)
            {
                index = 0;
            }
        }
    }

    void PlayDialogue(string text)
    {   
        StopAllCoroutines();
        fullText = text;
        dialogueText.text = " ";
        StartCoroutine(TypeAnimation(fullText));
    }

    IEnumerator TypeAnimation(string sentence)
    {   
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }
}
