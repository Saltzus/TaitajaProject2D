using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isTopDown = false;
    public bool isPlatformer = false;

    private Rigidbody2D rb;
    private Animation anim;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (isTopDown)
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);

            if (horizontal != 0f || vertical != 0f)
            {
                Debug.Log(horizontal);
                anim.Play("PlayerAnimation");
            }
            
        }
        else if (isPlatformer)
        {
            speed = speed * Time.deltaTime;

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && canJump)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                canJump = false;
            }



        }
        else
        {
            Debug.LogError("Please select either Top Down or Platformer controller.");
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
