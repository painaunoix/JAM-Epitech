using UnityEngine;

public class MobMovement : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH");
        //Destroy(other.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Vector3 targetPosition = Player.transform.position;
            if (targetPosition.x < transform.position.x)
                transform.Translate(Vector3.left * Time.deltaTime * 2);
            if (targetPosition.z < transform.position.z)
                transform.Translate(Vector3.back * Time.deltaTime * 2);
            if (targetPosition.y < transform.position.y)
                transform.Translate(Vector3.down * Time.deltaTime * 2);
            if (targetPosition.x > transform.position.x)
                transform.Translate(Vector3.right * Time.deltaTime * 2);
            if (targetPosition.z > transform.position.z)
                transform.Translate(Vector3.forward * Time.deltaTime * 2);
            if (targetPosition.y < transform.position.y)
                transform.Translate(Vector3.up * Time.deltaTime * 2);
        }
    }
}
