using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    public float speed = 3.0f;
    public float damage = 25.0f;
    public Transform frontCheck;
    public LayerMask layerMask;
    public AudioClip snakeDie;

    private AudioSource myAudioSource;
    private float facingRight = -1f;
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(new Vector3(facingRight, 0f, 0f) * speed * Time.deltaTime);

        if(Physics2D.OverlapPoint(frontCheck.position, layerMask))
        {
            facingRight *= -1f;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Die()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (var item in colliders)
        {
            item.enabled = false;
        }
        GetComponent<Rigidbody2D>().AddForce(new Vector2(4f, 8f), ForceMode2D.Impulse);
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);

        myAudioSource.pitch = Random.Range(0.5f, 1.5f);
        myAudioSource.PlayOneShot(snakeDie, 0.5f);

        Invoke("DisableObject", 2.0f);
    }

    private void DisableObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            collision.GetComponent<playerVariables>().Harm(damage);
        }
    }
}