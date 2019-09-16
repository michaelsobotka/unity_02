using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift_1 : MonoBehaviour
{

    public Transform left, right;
    public float moveSpeed = 2.0f;

    private bool movingRight;
    void Start()
    {
        movingRight = true;
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, right.position, moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, left.position, moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("liftTrigger"))
        {
            SwitchDirection();
        }

        if (collision.CompareTag("player"))
        {
            collision.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            collision.transform.parent = null;
        }
    }

    private void SwitchDirection()
    {
        movingRight = !movingRight;
    }
}
