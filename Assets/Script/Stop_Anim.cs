using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Stop_Anim : MonoBehaviour
{
    public Animator Anim;
    public string name;

    public void stop_Anim() {
        Anim.SetBool(name, false);
    }
}
