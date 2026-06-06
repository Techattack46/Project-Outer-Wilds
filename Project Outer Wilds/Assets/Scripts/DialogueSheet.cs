using UnityEngine;

[CreateAssetMenu(fileName ="NewNPCDialogue", menuName ="NPC Dialogue")]
public class DialogueSheet : ScriptableObject
{
    public string npcName;
    public string[] dialogueLines;

    public bool[] autoProgressLines;
    public bool[] dialogueBreak;
    public float autoProgressDelay = 1.5f;

    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;

    public DialogueChoice[] totalDialogueResponses;
}

[System.Serializable]
public class DialogueChoice
{
    public int dialogueIndex;
    public string[] responses;
    public int[] followUpIndex;
}