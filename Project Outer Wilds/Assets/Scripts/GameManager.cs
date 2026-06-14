using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject recruitMessagePrefab;
    public Transform canvasTransform;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameEnd();
        }
    }

    public IEnumerator SpawnRecruitMessage(string message)
    {
        Debug.Log(message);
        GameObject messageBox = Instantiate(recruitMessagePrefab, canvasTransform);

        messageBox.GetComponentInChildren<TMP_Text>().text = message;

        yield return new WaitForSeconds(3);

        Destroy(messageBox);
    }
    
    private void GameEnd()
    {
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }
}