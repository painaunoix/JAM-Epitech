using UnityEngine;
using System.Collections;

public class MobMoveSwitch : MonoBehaviour
{
    public MonoBehaviour behaviorA;
    public MonoBehaviour behaviorB;
    public float durationA = 10f;
    public float durationB = 10f;

    public GameObject fireball;
    public Transform shootingPoint;
    public Transform player;
    public float fireballSpeed = 10f;

    public float pushForce = 10f;
    public float pushRadius = 2f;

    public GameObject[] healthBars;
    public float maxHealth = 3f;
    private int currentHealth;

    private bool isBehaviorAActive = true;
    private float timer = 0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (behaviorA != null) behaviorA.enabled = true;
        if (behaviorB != null) behaviorB.enabled = false;
        currentHealth = (int)maxHealth;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isBehaviorAActive && timer >= durationA)
        {
            SwitchBehavior();
        }
        else if (!isBehaviorAActive && timer >= durationB)
        {
            SwitchBehavior();
        }
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void SwitchBehavior()
    {
        timer = 0f;
        isBehaviorAActive = !isBehaviorAActive;

        if (behaviorA != null) behaviorA.enabled = isBehaviorAActive;
        if (behaviorB != null) behaviorB.enabled = !isBehaviorAActive;

        if (isBehaviorAActive)
        {
            animator.SetBool("Move", false);
            StartCoroutine(FireballRoutine());
        } else
        {
            animator.SetBool("Move", true);
        }
    }

    IEnumerator FireballRoutine()
    {
        animator.SetTrigger("Cast");
        yield return new WaitForSeconds(1f);

        ShootFireball();
        Debug.Log("Fireball 1 launched");

        yield return new WaitForSeconds(6f);

        animator.SetTrigger("Cast");
        yield return new WaitForSeconds(1f);

        ShootFireball();
        Debug.Log("Fireball 2 launched");
    }


    void ShootFireball()
    {
        if (player != null && fireball != null)
        {
            GameObject newFireball = Instantiate(fireball, shootingPoint.position, Quaternion.identity);
            Vector3 direction = (player.position - shootingPoint.position).normalized;

            float randomSpeed = fireballSpeed * Random.Range(0.8f, 1.2f); // Ajoute une variation de vitesse
            newFireball.GetComponent<Rigidbody>().linearVelocity = direction * randomSpeed;

            Destroy(newFireball, 5f);
        }
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireBall"))
        {
            TakeDamage();
            Debug.Log($"Mob touché ! Vie restante : {currentHealth}");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("CCCCCCCCCCAAAAAAAAAAAAACCCCCCCCC");
            animator.SetTrigger("Cac");
        }
    }

    void UpdateHealthBar()
    {
        if (currentHealth < healthBars.Length && healthBars[currentHealth] != null)
        {
            healthBars[currentHealth].SetActive(false);
        }
    }

    void Die()
    {
        Debug.Log("Mob est mort");
        animator.SetTrigger("Death"); // Déclenche l'animation de mort
        GetComponent<Collider>().enabled = false; // Désactive les collisions
        this.enabled = false; // Désactive le script

        Destroy(gameObject, 3f); // Détruit l'ennemi après 3 secondes
    }

}
