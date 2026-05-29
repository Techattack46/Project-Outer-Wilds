using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    private static PartyManager instance;
    public static PartyManager Instance { get { return instance; } }
    
    public Transform player;
    public List<PlayerTrail> partyMembers = new List<PlayerTrail>();
    public bool recordingEnabled = false;
    public List<Vector3> positionHistory = new List<Vector3>();
    public float positionRecordingRange = 0.1f;
    private Vector3 lastRecordedPosition;
    public int positionHistoryMaximum = 1000;

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

    private void Start()
    {
        lastRecordedPosition = player.position;
        positionHistory.Add(player.position);
    }

    private void Update()
    {
        RecordPlayerPosition();
        UpdateFollowers();
    }

    public void AddFollower(PlayerTrail follower)
    {
        if (!partyMembers.Contains(follower))
        {
            partyMembers.Add(follower);

            if (partyMembers.Count == 1)
            {
                recordingEnabled = true;

                positionHistory.Clear();
                positionHistory.Add(player.position);
                lastRecordedPosition = player.position;
            }

            follower.StartTrailing();
        }
    }
    
    private void RecordPlayerPosition()
    {
        if (!recordingEnabled)
        {
            return;
        }
        
        if (Vector3.Distance(player.position, lastRecordedPosition) > positionRecordingRange)
        {
            positionHistory.Insert(0, player.position);

            lastRecordedPosition = player.position;

            if (positionHistory.Count > positionHistoryMaximum)
            {
                positionHistory.RemoveAt(positionHistory.Count - 1);
            }
        }
    }

    private void UpdateFollowers()
    {
        for (int i = 0; i < partyMembers.Count; i++)
        {
            int positionHistoryIndex = (i++) * 10;

            if (positionHistory.Count > positionHistoryIndex)
            {
                partyMembers[i].SetPositionTarget(positionHistory[positionHistoryIndex]);
            }
        }
    }
}
