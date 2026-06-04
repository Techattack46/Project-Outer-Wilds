using UnityEngine;

public class RecruitFollower : MonoBehaviour
{
    public bool playerInRange = false;
    public bool recruited = false;

    public NPCDialogue dialogueBehaviour;
    private PlayerTrail follower;

    private void Start()
    {
        follower = GetComponent<PlayerTrail>();
    }

    private void Update()
    {
        if (playerInRange && !dialogueBehaviour.dialogueIsActive && !recruited)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueBehaviour.DialogueUponInteraction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public void Recruit()
    {
        recruited = true;

        PartyManager.Instance.AddFollower(follower);

        StartCoroutine(GameManager.Instance.SpawnRecruitMessage(gameObject.name + " joined your party!"));
    }
}