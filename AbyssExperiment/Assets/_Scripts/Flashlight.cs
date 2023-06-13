using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Flashlight : MonoBehaviour
{
    public static GameObject Light;
    public bool LightOn = true;
    public bool Wait = true;
    public float BatteryPercent = 100;
    public bool Nobat;
    public Text test;

    public void OnClick(InputAction.CallbackContext context)
    {
        LightOn = context.ReadValueAsButton();
        Click();
    }

    // Start is called before the first frame update
    void Start()
    {
        Wait = true;
        GameObject theLight = GameObject.Find("Spot Light");
        Light = theLight;
    }

    // Update is called once per frame
    void Update()
    {
        test.text = BatteryPercent.ToString();


        //Input works
        //Turn Off
        if (Input.GetMouseButtonDown(0) && LightOn == true && Wait || Nobat)
        {      
            Light.SetActive(false);
            LightOn = false;
            Wait = false;
            StartCoroutine(FailSafe());
            Enemy.PlayerLightOn = false;
            

        }
        
        //Turn on
        if (Input.GetMouseButtonDown(0) && LightOn == false && Wait && !Nobat)
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

        if(PlayerStats.Batteries > 0 && BatteryPercent <= 0)
        {
            BatteryPercent = 100f;
            PlayerStats.Batteries--;
            Nobat= false;
        }


    }//Update

    void Click()
    {
        if (!LightOn)
        {
            Light.SetActive(false );
        }

        if (LightOn)
        {
            Light.SetActive(true);
        }

    }




    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(1f);
        Wait = true;
    }



}//class
