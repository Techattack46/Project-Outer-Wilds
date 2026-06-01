using System.Collections;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public DialogueSheet dialogueData;
    private DialogueManager manager;

    private int dialogueIndex;
    private bool isTyping, dialogueIsActive;
    public RecruitFollower recruitBehaviour;

    private void Start()
    {
        manager = DialogueManager.Instance;
    }

    public void DialogueUponInteraction()
    {
        Debug.Log("Dialogue has been interacted with.");
        
        if (dialogueData == null)
        {
            return;
        }

        manager.pauseForDialogue = true;
        
        if (dialogueIsActive)
        {
            DisplayNextDialogueLine();
        }
        else
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        Debug.Log("Starting dialogue.");
        
        dialogueIsActive = true;
        dialogueIndex = 0;

        manager.SetNPCName(dialogueData.npcName);
        manager.ShowDialoguePanel(true);

        DisplayCurrentLine();
    }

    private void DisplayNextDialogueLine()
    {
        Debug.Log("Displaying next dialogue line.");
        
        if (isTyping)
        {
            StopAllCoroutines();

            manager.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;

            return;
        }

        manager.ClearResponses();

        if (dialogueData.dialogueBreak.Length > dialogueIndex && dialogueData.dialogueBreak[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        dialogueIndex++;

        if (dialogueIndex < dialogueData.dialogueLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayCurrentLine()
    {
        StopAllCoroutines();
        StartCoroutine(Typewriter());
    }

    IEnumerator Typewriter()
    {
        isTyping = true;
        manager.SetDialogueText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            manager.SetDialogueText(manager.dialogueText.text += letter);
            //AudioManager.Instance.PlayClip(dialogueData.voiceSound, dialogueData.voicePitch);

            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if (AttemptResponseDisplay())
        {
            yield break;
        }

        if (dialogueIndex >=  dialogueData.dialogueLines.Length - 1)
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);

            EndDialogue();
            yield break;
        }

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);

            DisplayNextDialogueLine();
        }
    }

    private bool AttemptResponseDisplay()
    {
        foreach (DialogueChoice response in dialogueData.totalDialogueResponses)
        {
            if (response.dialogueIndex == dialogueIndex)
            {
                DisplayResponses(response);
                return true;
            }
        }

        return false;
    }

    private void DisplayResponses(DialogueChoice response)
    {
        for (int i = 0; i < response.responses.Length; i++)
        {
            int followUp = response.followUpIndex[i];
            manager.ResponseButtonSpawn(response.responses[i], () => ChooseResponse(followUp));
        }
    }

    private void ChooseResponse(int followUp)
    {
        dialogueIndex = followUp;
        manager.ClearResponses();

        DisplayCurrentLine();
    }

    public void EndDialogue()
    {
        Debug.Log("Ending dialogue.");
        
        StopAllCoroutines();

        dialogueIsActive = false;
        manager.SetDialogueText("");
        manager.ShowDialoguePanel(false);

        manager.pauseForDialogue = false;
        recruitBehaviour.Recruit();
    }
}