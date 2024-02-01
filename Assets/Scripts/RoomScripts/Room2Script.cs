using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Room2Script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Door;

    private GameObject DoorLeft;
    private GameObject DoorRight;
    private bool enemies = true;

    bool isCurrentlyColliding = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player")
        {

            isCurrentlyColliding = true;
        }
    }





    void Start()
    {
        //Close doors
        DoorLeft  = GameObject.Find("DoorLeft");
        DoorRight = GameObject.Find("DoorRight");

        Door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrentlyColliding && enemies)
        {


            DoorLeft.SetActive(true);
            DoorRight.SetActive(true);
            Door.SetActive(true);
        }



    }
}
