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
            BreakBarricade.Hit = other.gameObject;
            //play ANIMATION
            BreakBarricade.Destroy();
            BreakBarricade.Hit = null;
            Break.Play();

        }
    }//TriggerEnter
}//class
