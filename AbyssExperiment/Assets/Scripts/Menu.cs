using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
   public void Play()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
