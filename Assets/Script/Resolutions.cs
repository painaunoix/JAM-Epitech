using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resolutions : MonoBehaviour
{

    public TMP_Dropdown resolutionDropDown;
    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);

        if (PlayerPrefs.HasKey("resolutionIndex"))
        {
            int resolutionIndex = PlayerPrefs.GetInt("resolutionIndex");
            resolutionDropDown.value = resolutionIndex;
        }
        else
        {
            resolutionDropDown.value = currentResolutionIndex;
        }
        resolutionDropDown.RefreshShownValue();

        resolutionDropDown.value = GetCurrentResolutionIndex();
        resolutionDropDown.RefreshShownValue();
        resolutionDropDown.onValueChanged.AddListener(setResolution);
    }

    public void setResolution(int resolutionIndex)
    {
        if (resolutions == null || resolutionIndex < 0 || resolutionIndex >= resolutions.Length)
            return;

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("resolutionIndex"))
        {
            int resolutionIndex = PlayerPrefs.GetInt("resolutionIndex");
            resolutionDropDown.value = resolutionIndex;
            resolutionDropDown.RefreshShownValue();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("resolutionIndex", resolutionDropDown.value);
    }

    private int GetCurrentResolutionIndex()
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                return i;
            }
        }
        return 0;
    }
}
