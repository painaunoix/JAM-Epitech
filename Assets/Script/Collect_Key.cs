using UnityEngine;

public class Collect_Key : MonoBehaviour
{
    public bool key;
    public bool is_in;
    private TagHandle Player;
    public GameObject Key_Obj;

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
        key = false;
        is_in = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_in) {
            Destroy(Key_Obj);
            key = true;
        }
    }
}
