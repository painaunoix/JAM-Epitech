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
        if (!isInvulnerable) // Vérifie si le joueur est vulnérable
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
        yield return new WaitForSeconds(0.5f); // Le joueur est invulnérable 0.5 sec après un dégât
        isInvulnerable = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnnemiFireBall"))
        {
            TakeDamagePlayer();
            Debug.Log($"Player touché ! Vie restante : {currentHealth}");
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
