using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayEscape : MonoBehaviour
{
    public GameObject settingsPanel;
    public SoundManager soundManager;
    public Resolutions resolutionManager;
    public PlayerMovement playerController;
    public MouseLook cameraController;
    public PlayerScript playerScript;
    public Snap snap;
    public ForceController forceController;

    void Start()
    {
        LoadSettings();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerController.audioSource.Stop();
            bool isActive = !settingsPanel.activeSelf;
            settingsPanel.SetActive(isActive);
            ToggleCursor(isActive);
            ToggleControls(!isActive);
            SaveSettings();
        }

        if (settingsPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIElement())
            {
                SaveSettings();
                settingsPanel.SetActive(false);
                ToggleCursor(false);
                ToggleControls(true);
            }
        }
    }

    public void PressedButton()
    {
        bool isActive = !settingsPanel.activeSelf;
        settingsPanel.SetActive(isActive);
        ToggleCursor(isActive);
        ToggleControls(!isActive);
        SaveSettings();
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

    private void ToggleCursor(bool showCursor)
    {
        Cursor.lockState = showCursor ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = showCursor;
    }

    private void ToggleControls(bool enable)
    {
        if (playerController != null)
            playerController.enabled = enable;
        if (cameraController != null)
            cameraController.enabled = enable;
        if (playerScript != null)
            playerScript.enabled = enable;
        if (snap != null)
            snap.enabled = enable;
        if (forceController != null)
            forceController.enabled = enable;
    }
}
