using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public BoxCollider2D gameBounds;

    private Bounds bounds;
    private float camHalfHeight;
    private float camHalfWidth;

    private void Start()
    {
        bounds = gameBounds.bounds;

        Camera mainCam = Camera.main;
        camHalfHeight = mainCam.orthographicSize;
        camHalfWidth = camHalfHeight * mainCam.aspect;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float clampedX = Mathf.Clamp(
            player.position.x,
            bounds.min.x + camHalfWidth,
            bounds.max.x - camHalfWidth
        );

        float clampedY = Mathf.Clamp(
            player.position.y,
            bounds.min.y + camHalfHeight,
            bounds.max.y - camHalfHeight
        );

        transform.position = new Vector3(clampedX, clampedY, transform.position.z); 
    }
}