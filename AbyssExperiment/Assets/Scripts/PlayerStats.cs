using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public string Menu = "menu";

    public int Health;

    public int MaxHealth;

    public static int Batteries =0;

    public static bool attack;

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

       

        if(Health < 0)
        {
            Health = 0;
            SceneManager.LoadScene("menu");//Call Menu scene

        }


    }//Update

        public void PlayerAttacked(int Dmg)
        {
                Health -= Dmg;              
        }





    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "battery") 
        {
            Batteries++;
            Destroy(other.gameObject);
        }
    }

}//class
