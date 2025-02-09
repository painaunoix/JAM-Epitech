using UnityEngine;

public class MobMovement : MonoBehaviour
{
    public GameObject Player;
    private float speed;

    private void Start()
    {
        speed = Random.Range(5f, 15f);
    }

    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            direction.y = 0; // Bloque le mouvement vertical
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}
