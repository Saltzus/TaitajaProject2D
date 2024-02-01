using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Room5Script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Door;

    private GameObject DoorOwn;
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
        DoorOwn = GameObject.Find("Door5");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.Find("Enemies").childCount == 0)
        {
            enemies = false;
        }

        if (isCurrentlyColliding && enemies)
        {
            DoorOwn.SetActive(true);
            Door.SetActive(true);
        }
        if (!enemies)
        {
            DoorOwn.SetActive(false);
            Door.SetActive(false);
        }


    }
}
