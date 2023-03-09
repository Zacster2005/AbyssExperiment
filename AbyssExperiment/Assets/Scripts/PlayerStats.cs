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


    }
}//class
