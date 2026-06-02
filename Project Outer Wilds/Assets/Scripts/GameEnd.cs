using UnityEditor;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EditorApplication.isPlaying = false;
        }
    }
}