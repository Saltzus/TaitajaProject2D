using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Hand Hand = collision.gameObject.GetComponent<Hand>();
            if (Hand != null) { Hand.Equippowerup(3); }

        }
    }
}
