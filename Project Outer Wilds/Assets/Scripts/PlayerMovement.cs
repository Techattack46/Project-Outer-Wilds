using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    
    void Update()
    {
        MovementCheck();
    }

    private void MovementCheck()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;

        if (x != 0)
        {
            movement = new Vector3(x, 0);
        }
        else if (y != 0)
        {
            movement = new Vector3(0, y);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime);
    }
}