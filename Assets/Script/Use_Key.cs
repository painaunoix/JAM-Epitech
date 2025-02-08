using UnityEngine;

public class Use_Key : MonoBehaviour
{
    public GameObject wall;
    public Collect_Key Key;
    private TagHandle Player;
    public bool is_in;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_in && Key.key)
            wall.SetActive(false);
    }
}
