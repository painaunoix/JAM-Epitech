using UnityEngine;

public class Burn_Tree : MonoBehaviour
{
    private TagHandle fireBall;
    public GameObject fire;
    public GameObject Burned_tree;
    public GameObject Burnable_tree;
    public void OnEnable()
    {
        fireBall = TagHandle.GetExistingTag("FireBall");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(fireBall))
        {
            fire.SetActive(true);
            Burned_tree.SetActive(true);
            Burnable_tree.SetActive(false);
            Destroy(other.gameObject);
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
