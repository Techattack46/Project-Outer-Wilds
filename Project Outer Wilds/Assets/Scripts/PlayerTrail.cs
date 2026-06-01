using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public float MovementSpeed;
    public bool isTrailing;
    private Vector3 targetPosition;

    private SpriteRenderer spriteRenderer;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    public Sprite spriteUp;
    public Sprite spriteDown;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isTrailing)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, MovementSpeed * Time.deltaTime);

        Vector3 direction = targetPosition - transform.position;

        if (direction.x < -0.01f)
        {
            spriteRenderer.sprite = spriteLeft;
        }
        else if (direction.x > 0.01f)
        {
            spriteRenderer.sprite = spriteRight;
        }
        else if (direction.y > 0.01f)
        {
            spriteRenderer.sprite = spriteUp;
        }
        else if (direction.y < -0.01f)
        {
            spriteRenderer.sprite = spriteDown;
        }
    }
    
    public void StartTrailing()
    {
        isTrailing = true;
    }
    
    public void SetPositionTarget(Vector3 newTarget)
    {
        targetPosition = newTarget;
    }
}