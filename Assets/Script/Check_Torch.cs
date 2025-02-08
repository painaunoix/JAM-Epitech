using UnityEngine;

public class Check_Torch : MonoBehaviour
{
    public Torch Torch1;
    public Torch Torch2;
    public GameObject Door;

    void Update()
    {
        if (Torch1.is_Torch_Active == true && Torch2.is_Torch_Active == true)
            Door.SetActive(false);
    }
}
