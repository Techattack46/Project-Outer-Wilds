using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public static DialogueManager Instance { get { return instance; } }

    public bool pauseForDialogue = false;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Transform responsePanel;
    public GameObject responseButtonPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDialoguePanel(bool isShowing)
    {
        dialoguePanel.SetActive(isShowing);
    }

    public void SetNPCName(string npcName)
    {
        nameText.text = npcName;
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public void ClearResponses()
    {
        foreach (Transform child in responsePanel) Destroy(child.gameObject);
    }

    public GameObject ResponseButtonSpawn(string responseText, UnityEngine.Events.UnityAction onClick)
    {
        Debug.Log("Spawning in response buttons.");
        
        GameObject responseButton = Instantiate(responseButtonPrefab, responsePanel);

        responseButton.GetComponentInChildren<TMP_Text>().text = responseText;
        responseButton.GetComponent<Button>().onClick.AddListener(onClick);

        return responseButton;
    }
}