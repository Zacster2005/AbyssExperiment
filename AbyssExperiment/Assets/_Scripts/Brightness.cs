using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UIElements;

public class Brightness : MonoBehaviour
{
    public UnityEngine.UI.Slider brightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;
    private AutoExposure exposure;
    public TMP_Text brightnessLabel;
    void Start()
    {

        DontDestroyOnLoad(this);

        brightness.TryGetSettings(out exposure);
        AdjustBrightness(brightnessSlider.value);

        
    }

    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }

        else
        {
            exposure.keyValue.value = 0.05f;
        }

        brightnessLabel.text = Mathf.RoundToInt(brightnessSlider.value).ToString();
    }
}
