using Unity.VisualScripting;
using UnityEngine;

public class mobMovementOpositPlayer : MonoBehaviour
{
    public GameObject Player;
    public float safeDistance = 5f;
    private float moveSpeed;
    private void Start()
    {
        moveSpeed = Random.Range(5f, 15f);

    }

    void Update()
    {
        if (Player != null)
        {
            Vector3 directionToPlayer = transform.position - Player.transform.position;
            directionToPlayer.y = 0;

            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer < safeDistance)
            {
                Vector3 fleeDirection = directionToPlayer.normalized;
                transform.Translate(fleeDirection * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
