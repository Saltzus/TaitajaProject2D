using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordu : MonoBehaviour
{
    
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Hand Hand = col.gameObject.GetComponent<Hand>();
            if (Hand != null) { Hand.Equippowerup(0); }

        }
    }
}
