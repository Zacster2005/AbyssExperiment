using System.Collections;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public GameObject currentCheckpoint;
    
    public GameObject player;

    public float checkX;
    public float checkY;
    public float checkZ;

    public void Update()
    {
        checkX = currentCheckpoint.transform.position.x;
        checkY = currentCheckpoint.transform.position.y;
        checkZ = currentCheckpoint.transform.position.z;
    }

    public void RespawnPlayer()
    {
        player.transform.position = new Vector3 (checkX, checkY, checkZ);
        player.GetComponent<PlayerStats>().Health = player.GetComponent<PlayerStats>().MaxHealth;
    }
}//class



