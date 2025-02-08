using UnityEngine;
using System.Collections;

public class ParabolicProjectile : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float height = 2f;
    public ParticleSystem CanonParticles;
    public Torch torch;
    public bool isStart = false;

    private ParticleSystem CanonParticlesInstance;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timeToTarget;
    private float elapsedTime = 0f;
    private bool particlesSpawned = false;

    void StartBall()
    {
        startPosition = transform.position;
        targetPosition = target.position;
        timeToTarget = Vector3.Distance(startPosition, targetPosition) / speed;

        Invoke("SpawnCanonParticles", 0.01f);
    }

    void Update()
    {
        if (torch.is_Torch_Active == true && isStart == false) {
            isStart = true;
            StartBall();
        }
        if (isStart == true) {
            if (elapsedTime < timeToTarget)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / timeToTarget;

                Vector3 position = Vector3.Lerp(startPosition, targetPosition, t);
                position.y += Mathf.Sin(t * Mathf.PI) * height;
                transform.position = position;

                if (particlesSpawned && CanonParticlesInstance != null)
                {
                    CanonParticlesInstance.transform.position = transform.position;
                }
            }
            else
            {
                SpawnCanonParticles();
                StartCoroutine(Whait_Time(0.7f));
            }
        }
    }

    private void SpawnCanonParticles()
    {
        if (CanonParticles != null)
        {
            CanonParticlesInstance = Instantiate(CanonParticles, transform.position, Quaternion.identity, transform);
            CanonParticlesInstance.Play();
            particlesSpawned = true;

        }
    }

    private IEnumerator Whait_Time(float delay)
    {
        yield return new WaitForSeconds(delay);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        if (CanonParticlesInstance != null)
        {
            CanonParticlesInstance.Stop();
        }

        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
