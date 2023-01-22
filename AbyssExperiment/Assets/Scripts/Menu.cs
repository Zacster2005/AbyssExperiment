using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public string firstLevel;
    public GameObject optionsScreen;

    //Sounds
    public AudioSource Onclicksfx;

   public void Play()
    {
        Onclicksfx.Play();
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenOptions()
    {
        Onclicksfx.Play();
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        Onclicksfx.Play();
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
