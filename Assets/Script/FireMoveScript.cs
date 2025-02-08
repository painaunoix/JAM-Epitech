using UnityEngine;

public class FireMoveScript : MonoBehaviour
{
    public int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -5));
    }
}
