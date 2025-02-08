using UnityEngine;

public class PowerZone : MonoBehaviour
{
    public string powerName = "Fireball";
    public bool activateOnEnter = true;
    public PlayerPowers playerPowers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerPowers != null)
            {
                playerPowers.SetPowerState(powerName, activateOnEnter);
            }
        }
    }
}
