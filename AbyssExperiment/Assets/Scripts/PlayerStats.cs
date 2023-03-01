using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    

>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        if(attack)
        {
            Health--;
            attack= false;
        }
=======
>>>>>>> Stashed changes


        if (Health < 0)
        {
<<<<<<< Updated upstream
            Health= 0;
            PlayerDead = true;
        }
=======
            Health = 0;
        } 
>>>>>>> Stashed changes


    }//Update

    public static void Attacked()
    {
        attack = true;
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
