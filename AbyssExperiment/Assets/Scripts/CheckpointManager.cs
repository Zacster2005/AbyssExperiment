using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public List<GameObject> checkpoints;
    public GameObject currentCheckpoint;
    private Vector3 currentCheckpointPosition;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("checkpoint"))
            {
                checkpoints.Add(child.gameObject);
            }
        }
    }

    public void UpdateCurrentCheckpoint(GameObject newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
        checkpoints.Remove(newCheckpoint);
    }

    public void SetCurrentCheckpoint(Vector3 checkpointPosition)
    {
        currentCheckpointPosition = checkpointPosition;
    }

    public void RespawnPlayer(GameObject playerObject)
    {
        playerObject.transform.position = currentCheckpointPosition;
        playerObject.GetComponent<PlayerStats>().Health = playerObject.GetComponent<PlayerStats>().MaxHealth;
    }
}



