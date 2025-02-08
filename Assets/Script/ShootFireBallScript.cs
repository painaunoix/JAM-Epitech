using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject fireball;
    public PlayerPowers playerPowers;
    public GameObject TPBall;

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
        if (Input.GetKeyDown(KeyCode.E)) {
            if (playerPowers != null && playerPowers.HasPower("TPBall")) {
            Instantiate(TPBall, shootingPoint.transform.position, shootingPoint.rotation);
            }
        }
    }
}
