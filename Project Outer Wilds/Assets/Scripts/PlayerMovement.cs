using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    private SpriteRenderer spriteRenderer;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    public Sprite spriteUp;
    public Sprite spriteDown;

    public float horizontalEdge;
    public float verticalEdge;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (DialogueManager.Instance.pauseForDialogue)
        {
            return;
        }
        else
        {
            MovementCheck();
        }
    }

    private void MovementCheck()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;

        if (x != 0)
        {
            movement = new Vector3(x, 0);

            if (x < 0)
            {
                spriteRenderer.sprite = spriteLeft;
            }
            else
            {
                spriteRenderer.sprite = spriteRight;
            }
        }
        else if (y != 0)
        {
            movement = new Vector3(0, y);

            if (y > 0)
            {
                spriteRenderer.sprite = spriteUp;
            }
            else
            {
                spriteRenderer.sprite = spriteDown;
            }
        }

        transform.Translate(movementSpeed * Time.deltaTime * movement);

        Vector3 playerPosition = transform.position;

        playerPosition.x = Mathf.Clamp(
            playerPosition.x,
            -horizontalEdge,
            horizontalEdge
        );
        
        playerPosition.y = Mathf.Clamp(
            playerPosition.y,
            -verticalEdge,
            verticalEdge
        );

        transform.position = playerPosition;
    }
}