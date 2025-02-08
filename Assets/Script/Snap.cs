using UnityEngine;
using System;
using System.Collections;
using TMPro; // Utilisation de TextMeshPro

public class Snap : MonoBehaviour
{
    public GameObject futur;
    public GameObject present;
    public bool present_state;
    public Animator snap_Anim;
    public bool auth_snap;

    public TMP_Text timeRemainingText;
    private float timeToNextSnap = 0f;
    private bool isWaitingForSnap = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (present_state == true && auth_snap) {
                snap_to_future();
            }
            else {
                snap_to_present();
            }
        }
    }

    public void snap_to_future()
    {
        futur.SetActive(true);
        present.SetActive(false);
        present_state = false;
        snap_Anim.SetBool("snap", true);
        auth_snap = false;
        timeToNextSnap = 5f;
        StartCoroutine(snap_to_future_cour());
    }

    public void snap_to_present()
    {
        if (!present_state) {
            futur.SetActive(false);
            present.SetActive(true);
            present_state = true;
            snap_Anim.SetBool("snap", true);
            auth_snap = false;
            timeToNextSnap = 15f;
            StopCoroutine(snap_to_future_cour());
            StartCoroutine(snap_to_present_cour());
        }
    }

    IEnumerator snap_to_future_cour()
    {
        isWaitingForSnap = true;
        while (timeToNextSnap > 0) {
            timeToNextSnap -= Time.deltaTime;
            timeRemainingText.text = Mathf.Ceil(timeToNextSnap) + "s";
            yield return null;
        }
        snap_to_present();
        isWaitingForSnap = false;
    }

    IEnumerator snap_to_present_cour()
    {
        isWaitingForSnap = true;
        while (timeToNextSnap > 0) {
            timeToNextSnap -= Time.deltaTime;
            timeRemainingText.text = Mathf.Ceil(timeToNextSnap) + "s";
            yield return null;
        }
        timeRemainingText.text = "";
        auth_snap = true;
        isWaitingForSnap = false;
    }
}