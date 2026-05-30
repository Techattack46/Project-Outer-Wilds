using UnityEngine;

public class RecruitFollower : MonoBehaviour
{
    public bool playerInRange = false;
    public bool recruited = false;

    private PlayerTrail follower;

    private void Start()
    {
        follower = GetComponent<PlayerTrail>();
    }

    private void Update()
    {
        if (playerInRange && !recruited)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Recruit();
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

    private void Recruit()
    {
        recruited = true;

        PartyManager.Instance.AddFollower(follower);

        Debug.Log(gameObject.name + " joined the Party!");
    }
}