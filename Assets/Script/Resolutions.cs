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
        Load();

        resolutionDropDown.onValueChanged.AddListener(setResolution);
    }

    public void setResolution(int resolutionIndex)
    {
        if (resolutions == null)
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
            setResolution(resolutionIndex);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("resolutionIndex", resolutionDropDown.value);
    }
}
