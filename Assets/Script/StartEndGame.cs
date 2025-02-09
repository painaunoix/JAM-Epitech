using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndGame : MonoBehaviour
{
    public bool is_in;
    private TagHandle Player;

    public void OnEnable()
    {
        Player = TagHandle.GetExistingTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player)) {
            is_in = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Player)) {
            is_in = false;
        }
    }

    void Start()
    {
        is_in = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_in) {
            SceneManager.LoadScene("Outro");
        }
    }
}
