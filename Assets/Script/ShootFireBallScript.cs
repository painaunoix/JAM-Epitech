using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject fireball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(fireball, shootingPoint.transform.position, shootingPoint.rotation);
        }
    }
}
