using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using UnityEngine.Rendering.PostProcessing;

public class Options : MonoBehaviour
{
    public UnityEngine.UI.Toggle fullscreenTog, vsyncTog;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;
    public AudioMixer theMixer;
    public TMP_Text mastLabel, musicLabel, sfxLabel, msensLabel;
    public UnityEngine.UI.Slider mastSlider, musicSlider, sfxSlider, msensSlider;



    private void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }

            float vol = 0;
            theMixer.GetFloat("MasterVol", out vol);
            mastSlider.value = vol;
            theMixer.GetFloat("MusicVol", out vol);
            musicSlider.value = vol;
            theMixer.GetFloat("SFXVol", out vol);
            sfxSlider.value = vol;


            mastLabel.text = Mathf.RoundToInt(mastSlider.value + 50).ToString();
            musicLabel.text = Mathf.RoundToInt(musicSlider.value + 50).ToString();
            sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 60).ToString();
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;
            UpdateResLabel();


        }


    }





    public void ResRight()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }

        UpdateResLabel();
    }

    public void ResLeft()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn;
        if (fullscreenTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 50).ToString();

        theMixer.SetFloat("MasterVol", mastSlider.value);

        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }

    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 50).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 60).ToString();

        theMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

    public void SetMouseSensVal()
    {
        msensLabel.text = Mathf.RoundToInt(msensSlider.value).ToString();

        PlayerLook.mouseSens = msensSlider.value;



    }


}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}