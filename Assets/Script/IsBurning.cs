using UnityEngine;

public class IsBurning : MonoBehaviour
{
    public bool burning;
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("FireBall") && burning != true)
        {
            burning = true;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
