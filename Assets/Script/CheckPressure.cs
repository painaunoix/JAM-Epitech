using UnityEngine;

public class CheckPressure : MonoBehaviour
{
    public Press Press1;
    public Press Press2;
    public GameObject Door;

    void Update()
    {
        if (Press1.isPressed == true && Press2.isPressed == true)
            Door.SetActive(false);
        else
            Door.SetActive(true);
    }
}
