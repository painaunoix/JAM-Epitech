using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public Slider volumeSlide;

    void Start()
    {
        Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlide.value;
        Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            volumeSlide.value = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            volumeSlide.value = 1;
        }
        AudioListener.volume = volumeSlide.value;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlide.value);
    }
}
