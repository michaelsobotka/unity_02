﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("player"))
        {
            GetComponentInParent<snake>().Die();
            gameObject.SetActive(false);
        }
    }

}
