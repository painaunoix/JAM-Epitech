using UnityEngine;
using TMPro;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private string message = "Hmm, il faudrait faire quelque chose ici...";
    [SerializeField] private TextMeshProUGUI textUI;

    private void Start()
    {
        if (textUI != null)
            textUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (textUI != null)
            {
                textUI.text = message;
                textUI.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (textUI != null)
                textUI.gameObject.SetActive(false);
        }
    }
}
