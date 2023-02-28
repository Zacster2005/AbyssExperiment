using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
  
    public bool alreadyInspected = false;

    public bool NotesNearby;

    public int NotesCount = 0;

    public Text NoteText;

    public GameObject LastNote;

    [Header("Note Content")]

    public string[] notes;

    public string Empty;

   


    // Start is called before the first frame update
    void Start()
    {
        
    }//start

    // Update is called once per frame
    void Update()
    {
        if (NotesNearby && Input.GetKey(KeyCode.E))
        {
            if (NotesCount == 0 && !alreadyInspected)
            {
                Debug.Log("NotesInspected!");
                NotesCount = NotesCount + 1;
                NoteText.text = notes[NotesCount - 1];
                NotesNearby = false;
                alreadyInspected= true;
            }

            if (NotesCount == 1 && !alreadyInspected)
            {
                Debug.Log("NotesInspected!");
                NotesCount = NotesCount + 1;
                NoteText.text = notes[NotesCount - 1];
                NotesNearby = false;
                alreadyInspected = true;
            }

            if (NotesCount == 2 && !alreadyInspected)
            {
                Debug.Log("NotesInspected!");
                NotesCount = NotesCount + 1;
                NoteText.text = notes[NotesCount - 1];
                NotesNearby = false;
                alreadyInspected = true;
            }

            if (NotesCount == 3 && !alreadyInspected)
            {
                Debug.Log("NotesInspected!");
                NotesCount = NotesCount + 1;
                NoteText.text = notes[NotesCount - 1];
                NotesNearby = false;
                alreadyInspected = true;
            }

        }
    }//update


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Note")
        {
            Debug.Log("NotesNearby!");
            NotesNearby = true;
            LastNote = other.gameObject;
        }
    }//tEnter

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            if (!NotesNearby)
            {
                Debug.Log("NoNotes!");
                NotesNearby = false;
                NoteText.text = Empty;
                LastNote.tag = "Untagged";

            }

            NotesNearby = false;
            alreadyInspected = false;
        }
    }//Texit


}//class
