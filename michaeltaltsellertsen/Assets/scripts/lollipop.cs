using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lollipop : MonoBehaviour
{
    public float damage = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            collision.GetComponent<playerVariables>().Harm(damage);
        }
    }
}
