using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject check = GameObject.Find("CheckpointManager");
            CheckpointManager checkpointM = check.GetComponent<CheckpointManager>();
            checkpointM.currentCheckpoint = this.transform;
        }
    }
}
