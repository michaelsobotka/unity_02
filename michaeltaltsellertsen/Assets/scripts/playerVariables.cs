using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerVariables : MonoBehaviour
{

    public Transform StartPosition;
    public float health = 100.0f;
    public GameObject coinParticles;
    public AudioClip coinPickup;
    public AudioClip harm;
    public Transform uiCoin;

    private float damageTimer;
    private AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        damageTimer += Time.deltaTime;
        gameController.gameControllerInstance.playerHealth = health;
    }

    public void Harm(float damage)
    {
        if(damageTimer > 1.0f)
        {
            health -= damage;
            damageTimer = 0;
            gameController.gameControllerInstance.ScreenShake();
            myAudioSource.pitch = Random.Range(0.5f, 1.5f);
            myAudioSource.PlayOneShot(harm, 0.5f);
        }

        if(health < 1)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = StartPosition.position;
        health = 100;
        //rgb2d.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.gameObject.CompareTag("coin"))
        {
            coin.gameObject.SetActive(false);
            Instantiate(coinParticles, coin.transform.position, Quaternion.identity);
            gameController.gameControllerInstance.coins++;
            uiCoin.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.2f, 4, 4);

            myAudioSource.pitch = Random.Range(0.5f, 1.5f);
            myAudioSource.PlayOneShot(coinPickup, 0.5f);
        }
    }

}
