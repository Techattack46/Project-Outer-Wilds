using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}