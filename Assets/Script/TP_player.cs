using UnityEngine;

public class TP_player : MonoBehaviour
{
    private TagHandle fireBall;
    public GameObject player;

    public void OnEnable()
    {
        fireBall = TagHandle.GetExistingTag("TPBall");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(fireBall))
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            controller.enabled = false;
            player.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            controller.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
