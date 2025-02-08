using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour
{
    private TagHandle fireBall;
    public GameObject fire;
    public bool is_Torch_Active;
    public void OnEnable()
    {
        fireBall = TagHandle.GetExistingTag("FireBall");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(fireBall))
        {
            fire.SetActive(true);
            is_Torch_Active = true;
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        is_Torch_Active = false;
    }

    void Update()
    {
        
    }
}
