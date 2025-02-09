using UnityEngine;

public class Press : MonoBehaviour
{
    public bool isPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.CompareTag("Interactable"))
        {
            isPressed = true;
        }
    }

    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.CompareTag("Interactable")) 
        {
            isPressed = false;
        }
    }
}
