using UnityEngine;
using System.Collections.Generic;

public class PlayerPowers : MonoBehaviour
{
    private Dictionary<string, bool> powers = new Dictionary<string, bool>();

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
    }

    public bool HasPower(string powerName)
    {
        return powers.ContainsKey(powerName) && powers[powerName];
    }
}
