using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformInputs : MonoBehaviour
{
    public float horizontalSpeed = 0.0f;
    public Transform groundcheck;
    public float jumpHeight = 0.0f;
    public Rigidbody2D rigidBody;
    public bool grounded;

    private float horizontalDirection;
    private Animator playerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalDirection, 0, 0) * horizontalSpeed * Time.deltaTime, Camera.main.transform);

        grounded = Physics2D.OverlapPoint(groundcheck.position);

        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity += new Vector2(0, jumpHeight);
        }

        if (horizontalDirection > 0)
        {
            Flip(2);
        }
        else if(horizontalDirection < 0)
        {
            Flip(-2);
        }

        playerAnimator.SetFloat("speed", Mathf.Abs(horizontalDirection));
    }

    private void Flip(int facingRight)
    {
        Vector3 myScale = transform.localScale;
        myScale.x = facingRight;
        transform.localScale = myScale;
    }

}
