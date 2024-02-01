using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenChest : MonoBehaviour
{
    // Start is called before the first frame update
    bool isCurrentlyColliding = false;
    private SpriteRenderer sprite;
    public Sprite OpenChestTexture;


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
        if (isCurrentlyColliding)
        {
            sprite.sprite = OpenChestTexture;
        }
    }
}
