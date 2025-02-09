using UnityEngine;

public class MobMovement : MonoBehaviour
{
    public GameObject Player;
    private float speed;
    private Animator animator;
    public MobMoveSwitch mobMoveSwitch;

    private void Start()
    {
        speed = 7f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player != null && mobMoveSwitch.dead == false)
        {
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            direction.y = 0;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            animator.SetBool("Move", true);
        }
    }
}
