using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public Text Read;

    bool AlreadyRead = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Note")
        {
            if(Input.GetKey(KeyCode.E))
            {
                Note2 NoteScript = other.GetComponent<Note2>();
                NoteScript.ReadNote();
                AlreadyRead = true; 
            }
            
        if(AlreadyRead)
            {
                Note2 NoteScript = other.GetComponent<Note2>();
                NoteScript.ReadNote();
            }
            
        }
    }//Enter

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            Read.text = string.Empty;
        }
    }

}//class
