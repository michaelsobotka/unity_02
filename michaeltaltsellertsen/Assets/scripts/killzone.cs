using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killzone : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("player"))
        {
            player.gameObject.GetComponent<playerVariables>().Respawn();
        }
    }
}
