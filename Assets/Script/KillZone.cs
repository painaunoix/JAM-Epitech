using UnityEngine;

public class KillZone : MonoBehaviour
{
    public GameObject player;
    public GameObject checkPoint;

    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            controller.enabled = false;
            player.transform.position = checkPoint.transform.position;
            controller.enabled = true;
        }
    }
}
