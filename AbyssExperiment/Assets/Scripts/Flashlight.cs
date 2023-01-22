using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public GameObject Light;
    public bool LightOn;
    public bool Wait = true;
    public float BatteryPercent = 100;
    public bool Nobat;
    public Text test;

    // Start is called before the first frame update
    void Start()
    {
        LightOn = true;
        Wait = true;
    }

    // Update is called once per frame
    void Update()
    {
        test.text = BatteryPercent.ToString();


        //Input works
        //Turn ON
        if (Input.GetMouseButton(0) && LightOn == true && Wait || Nobat)
        {      
            Light.SetActive(false);
            LightOn = false;
            Wait = false;
            StartCoroutine(FailSafe());
            Enemy.PlayerLightOn = false;
            

        }
        
        //Turn OFF
        if (Input.GetMouseButton(0) && LightOn == false && Wait && !Nobat)
        {
            Light.SetActive(true);
            LightOn = true;
            Wait = false;
            StartCoroutine(FailSafe());
            Enemy.PlayerLightOn = true;
        }

        if(LightOn)
        {
            BatteryPercent = BatteryPercent -1f * Time.deltaTime;
        }


        if(BatteryPercent > 0)
        {
            Nobat= false;
        }
        
        if(BatteryPercent< 0)
        {
            Nobat= true;
        }

        if(PlayerStats.Batteries > 0)
        {
            BatteryPercent = 100f;
            PlayerStats.Batteries--;
            Nobat= false;
        }


    }//Update

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(1f);
        Wait = true;
    }


}//class
