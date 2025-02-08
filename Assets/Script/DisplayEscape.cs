using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayEscape : MonoBehaviour
{
    public GameObject settingsPanel;
    public SoundManager soundManager;
    public Resolutions resolutionManager;

    void Start()
    {
        LoadSettings();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
            SaveSettings();
        }

        if (settingsPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIElement())
            {
                SaveSettings();
                settingsPanel.SetActive(false);
            }
        }
    }

    public void PressedButton()
    {
        SaveSettings();
        settingsPanel.SetActive(false);
    }


    private bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    private void SaveSettings()
    {
        if (soundManager != null)
            soundManager.Save();
        if (resolutionManager != null)
            resolutionManager.Save();
    }

    private void LoadSettings()
    {
        if (soundManager != null)
            soundManager.Load();
        if (resolutionManager != null)
            resolutionManager.Load();
    }
}
