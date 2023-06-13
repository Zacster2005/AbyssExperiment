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
        StartCoroutine(StartGame());
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

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(firstLevel);
    }



}//class
