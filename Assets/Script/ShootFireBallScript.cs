using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject fireball;
    public PlayerPowers playerPowers;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (playerPowers != null && playerPowers.HasPower("Fireball")) {
                Instantiate(fireball, shootingPoint.transform.position, shootingPoint.rotation);
            }
        }
    }
}
