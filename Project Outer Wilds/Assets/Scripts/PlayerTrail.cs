using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public float MovementSpeed;
    private Vector3 targetPosition;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, MovementSpeed * Time.deltaTime);
    }
    
    public void SetPositionTarget(Vector3 newTarget)
    {
        targetPosition = newTarget;
    }
}