using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    float distance;
    public GameObject player;
    
    private Animation anim;
    private Rigidbody2D rb;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {

        var step = speed * Time.deltaTime;

        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (distance < 8)
        {
            anim.Play("EnemyAnimation");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
            Debug.Log("AMONGUUUSSSS");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
