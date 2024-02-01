using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GoldenChest : MonoBehaviour
{
    // Start is called before the first frame update
    bool isCurrentlyColliding = false;
    private SpriteRenderer sprite;
    public Sprite OpenChestTexture;
    private bool chestopen = false;
    public GameObject shoes;
    public GameObject damageboost;
    public GameObject sword;
    public GameObject i1;
    public GameObject i2;
    public GameObject i3;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isCurrentlyColliding = true;
        }
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrentlyColliding && chestopen == false)
        {
            sprite.sprite = OpenChestTexture;
            shoes = Instantiate(shoes, i1.transform.position, Quaternion.identity);
            damageboost = Instantiate(shoes, i2.transform.position, Quaternion.identity);
            sword = Instantiate(shoes, i3.transform.position, Quaternion.identity);
            chestopen = true;

        }
    }
}
