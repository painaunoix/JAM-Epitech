using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject fireball;
    public PlayerPowers playerPowers;
    public GameObject TPBall;
    public SpellSelector spellSelector;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (playerPowers != null && playerPowers.HasPower("Fireball") && spellSelector.Spell_Active == 2) {
                Instantiate(fireball, shootingPoint.transform.position, shootingPoint.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            if (playerPowers != null && playerPowers.HasPower("TPBall") && spellSelector.Spell_Active == 4) {
            Instantiate(TPBall, shootingPoint.transform.position, shootingPoint.rotation);
            }
        }
    }
}
