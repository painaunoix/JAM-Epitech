using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    public GameObject Spell_1;
    public GameObject Spell_2;
    public GameObject Spell_3;
    public GameObject Spell_4;

    public int Spell_Active = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Spell_Active == 1) {
            Spell_1.SetActive(true);
            Spell_2.SetActive(false);
            Spell_3.SetActive(false);
            Spell_4.SetActive(false);
        }
        if (Spell_Active == 2) {
            Spell_1.SetActive(false);
            Spell_2.SetActive(true);
            Spell_3.SetActive(false);
            Spell_4.SetActive(false);
        }
        if (Spell_Active == 3) {
            Spell_1.SetActive(false);
            Spell_2.SetActive(false);
            Spell_3.SetActive(true);
            Spell_4.SetActive(false);
        }
        if (Spell_Active == 4) {
            Spell_1.SetActive(false);
            Spell_2.SetActive(false);
            Spell_3.SetActive(false);
            Spell_4.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Spell_Active = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Spell_Active = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Spell_Active = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Spell_Active = 4;
    }
}
