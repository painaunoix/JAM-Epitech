using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    public GameObject[] healthBars;
    public float maxHealth = 3f;
    private bool isInvulnerable = false;
    public int currentHealth = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void TakeDamagePlayer()
    {
        if (!isInvulnerable) // V�rifie si le joueur est vuln�rable
        {
            currentHealth--;
            StartCoroutine(InvulnerabilityCooldown());

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    IEnumerator InvulnerabilityCooldown()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(0.5f); // Le joueur est invuln�rable 0.5 sec apr�s un d�g�t
        isInvulnerable = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnnemiFireBall"))
        {
            TakeDamagePlayer();
            Debug.Log($"Player touch� ! Vie restante : {currentHealth}");
        }
    }

    void Update()
    {
        if (currentHealth <= 2)
            healthBars[2].SetActive(false);
        if (currentHealth <= 1)
            healthBars[1].SetActive(false);
        if (currentHealth <= 0)
            healthBars[0].SetActive(false);
    }

    void Die()
    {
        Debug.Log("Mob est mort");
    }   
}
