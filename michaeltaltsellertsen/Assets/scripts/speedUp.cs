using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUp : MonoBehaviour
{
    public AudioClip powerup;

    private AudioSource myAudioSource;
    private float startSpeed;
    private float startJumpHeight;
    private bool active = true;
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("player") && active)
        {
            active = false;
            startSpeed = collider.GetComponent<platformInputs>().horizontalSpeed;
            startJumpHeight = collider.GetComponent<platformInputs>().jumpHeight;
            collider.GetComponent<platformInputs>().horizontalSpeed *= 1.5f;
            collider.GetComponent<platformInputs>().jumpHeight *= 1.5f;
            myAudioSource.pitch = 1f;
            myAudioSource.PlayOneShot(powerup, 0.5f);
            yield return new WaitForSeconds(3.0f);
            collider.GetComponent<platformInputs>().horizontalSpeed = startSpeed;
            collider.GetComponent<platformInputs>().jumpHeight = startJumpHeight;
            myAudioSource.pitch = 0.5f;
            myAudioSource.PlayOneShot(powerup, 0.5f);
            active = true;


        }
    }
}
