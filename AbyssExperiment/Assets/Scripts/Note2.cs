using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note2 : MonoBehaviour
{
    public string Note;

    public Text Read;

    public void ReadNote()
    {
        Read.text = Note;
        Debug.Log("ReadNotes");
    }


}//class
