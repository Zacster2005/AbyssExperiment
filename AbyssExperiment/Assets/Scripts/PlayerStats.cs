using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public static int Batteries = 0;
    public Text HealthVal;
    public static bool PlayerDead;
    private Vector3 checkpointPosition;
    public CheckpointManager checkpointManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HealthVal.text = Health.ToString();

        if (Health <= 0)
        {
            // Set PlayerDead to true and pause the game
            PlayerDead = true;
            GameObject UI = GameObject.Find("Canvas");
            PauseMenu pauseMenu = UI.GetComponent<PauseMenu>();
            pauseMenu.Pause();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        checkpointPosition = position;
    }

    public void Attacked()
    {
        Health--;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "battery")
        {
            Batteries++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "checkpoint")
        {
            // Update the current checkpoint position
            PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
            pauseMenu.SetCheckpoint(other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
