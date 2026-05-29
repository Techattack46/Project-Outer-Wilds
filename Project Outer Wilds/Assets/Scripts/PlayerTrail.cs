using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public float MovementSpeed;
    public bool isTrailing;
    private Vector3 targetPosition;

    private void Update()
    {
        if (!isTrailing)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, MovementSpeed * Time.deltaTime);
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