using System.Collections;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public Transform currentCheckpoint;
    
    public GameObject player;

    public bool playerDead = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
       if(playerDead)
        {
            player.transform.position = new Vector3(currentCheckpoint.position.x, currentCheckpoint.position.y, currentCheckpoint.position.z);
            player.GetComponent<PlayerStats>().Health = player.GetComponent<PlayerStats>().MaxHealth;
        }
    }

    public void RespawnPlayer()
    {
        playerDead = true;
        StartCoroutine(Reset());
    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(2f);
        playerDead = false;
    }

}//class



