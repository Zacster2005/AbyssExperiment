using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public static int Batteries = 0, Collectibles;
    public Text HealthVal;
    public static bool PlayerDead, AttackWait = true;
    public AudioSource Death;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HealthVal.text = Health.ToString();

        if(Health == -1)
        {
            Debug.Log("ISDEAD");
            Death.Play();
        }


        if (Health <= 0)
        {
            // Set PlayerDead to true and pause the game
            GameObject UI = GameObject.Find("Canvas");
            PauseMenu pauseMenu = UI.GetComponent<PauseMenu>();
            pauseMenu.Pause();
            Cursor.lockState = CursorLockMode.Confined;
            Death.Play();
        }
    }



    public void Attacked()
    {
        if (AttackWait)
        {
            Health--;
            AttackWait = false;
            StartCoroutine(Reset());
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "battery")
        {
            Batteries++;
            Destroy(other.gameObject);
        }


    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3);
        AttackWait = true;
    }
}//class
