using UnityEngine;

public class SpawnEnnemi : MonoBehaviour
{

    public GameObject Ennemi;
    public GameObject bar;
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
        if (collide.gameObject.CompareTag("Player"))
        {
            Ennemi.SetActive(true);
            bar.SetActive(true);
        }
    }
}
