using Unity.VisualScripting;
using UnityEngine;

public class mobMovementOpositPlayer : MonoBehaviour
{
    public GameObject Player;
    public float safeDistance = 5f;
    private float moveSpeed;
    private Animator animator;

    public MobMoveSwitch mobMoveSwitch;

    private void Start()
    {
        animator = GetComponent<Animator>();
        moveSpeed = 7f;
    }

    void Update()
    {
        if (Player != null && mobMoveSwitch.dead == false)
        {
            Vector3 directionToPlayer = transform.position - Player.transform.position;
            directionToPlayer.y = 0;

            float distanceToPlayer = directionToPlayer.magnitude;

            animator.SetBool("MoveBack", false);
            if (distanceToPlayer < safeDistance - 10)
                animator.SetBool("MoveBack", true);
            if (distanceToPlayer < safeDistance)
            {
                Vector3 fleeDirection = directionToPlayer.normalized;
                transform.Translate(fleeDirection * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
