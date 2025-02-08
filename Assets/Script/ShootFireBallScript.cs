using UnityEngine;
using System;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject fireball;
    public PlayerPowers playerPowers;
    public GameObject TPBall;
    public SpellSelector spellSelector;
    public bool fireball_ready;
    public bool TPball_ready;

    void Start()
    {
        fireball_ready = true;
        TPball_ready = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (playerPowers != null && playerPowers.HasPower("Fireball") && spellSelector.Spell_Active == 2 && fireball_ready) {
                fireball_ready = false;
                Instantiate(fireball, shootingPoint.transform.position, shootingPoint.rotation);
                StartCoroutine(fireball_cour());
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            if (playerPowers != null && playerPowers.HasPower("TPBall") && spellSelector.Spell_Active == 4 && TPball_ready) {
                TPball_ready = false;
                Instantiate(TPBall, shootingPoint.transform.position, shootingPoint.rotation);
                StartCoroutine(TPball_cour());
            }
        }
    }
    IEnumerator fireball_cour()
    {
        yield return new WaitForSeconds(1f);
        fireball_ready = true;
    }
    IEnumerator TPball_cour()
    {
        yield return new WaitForSeconds(1f);
        TPball_ready = true;
    }
}
