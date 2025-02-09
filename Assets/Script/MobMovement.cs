using UnityEngine;

public class MobMovement : MonoBehaviour
{
    public GameObject Player;
    private float speed;
    private Animator animator;

    private void Start()
    {
        speed = Random.Range(5f, 15f);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            direction.y = 0;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            animator.SetBool("Move", true);
        }
    }
}
