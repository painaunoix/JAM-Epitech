using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour
{
    private TagHandle fireBall;
    public GameObject fire;
    public void OnEnable()
    {
        fireBall = TagHandle.GetExistingTag("Fire_ball");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(fireBall))
        {
            fire.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
