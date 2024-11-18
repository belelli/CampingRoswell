using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private float TypingTime = 0.05f;
    [SerializeField] private GameObject DialogueMark;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.M))
        {
            if (!didDialogueStart)
            {
                StartDialogue();

            }
            else if (dialogueText.text == dialogueLines[lineIndex]) 
            {
                NextDialogueLine();
            
            }
            else 
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            
            }

        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        DialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());

    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length) 
        {
            StartCoroutine(ShowLine());
        
        }
        else 
        {
            didDialogueStart = false;
            DialoguePanel.SetActive (false);
            DialogueMark.SetActive(true);
            Time.timeScale = 1f;

            SceneManager.LoadScene("Final");

        }
    
    }

    private IEnumerator ShowLine() 
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(TypingTime);
        
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            DialogueMark.SetActive(true);
            Debug.Log("Se puede iniciar Dialogo");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            DialogueMark.SetActive(false);
            Debug.Log("No se puede iniciar Dialogo");

        }

    }
}
