using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{

    public AudioSource Break;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Breakable")
        {
           Destroy(other.gameObject);
            Break.Play();
        }

        if(other.gameObject.tag == "Door")
        {
            //open door audio
 
        }

    }//TriggerEnter
}//class
