using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            volumeSlider.value = 1;
        }
        AudioListener.volume = volumeSlider.value;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
