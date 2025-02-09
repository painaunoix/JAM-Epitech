using UnityEngine;
using System.Collections.Generic;

public class PlayerPowers : MonoBehaviour
{
    private Dictionary<string, bool> powers = new Dictionary<string, bool>();
    public GameObject[] icons;

    private void Start()
    {
        powers["Fireball"] = false;
        powers["Snap"] = false;
        powers["Telekinesis"] = false;
        powers["TPBall"] = false;
    }

    public void SetPowerState(string powerName, bool state)
    {
        if (powers.ContainsKey(powerName))
        {
            powers[powerName] = state;
        }
        if (powerName == "Snap")
            icons[0].SetActive(true);
        if (powerName == "Fireball")
            icons[1].SetActive(true);
        if (powerName == "Telekinesis")
            icons[2].SetActive(true);
        if (powerName == "TPBall")
            icons[3].SetActive(true);
    }

    public bool HasPower(string powerName)
    {
        return powers.ContainsKey(powerName) && powers[powerName];
    }
}
