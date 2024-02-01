using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand;
    public GameObject handpivot;
    public Transform spawnPoint;
    public GameObject swingPre;
    public float chargeTime = 2.0f;
    public int swingspeed = 10;
    public float cooldownTime = 1.0f;

    private bool isCharging = false;
    private float chargeTimer = 0.0f;
    private float cooldownTimer = 0.0f;
    private GameObject swing; // Variable to store the instantiated swing

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && cooldownTimer <= 0)
        {
            StartCharge();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseAttack();
        }

        if (isCharging)
        {
            chargeTimer += Time.deltaTime;

            if (chargeTimer >= chargeTime)
            {
                ReleaseAttack();
            }
        }

        // Rotate handpivot towards mouse position
        RotateHandPivotTowardsMouse();
    }

    void StartCharge()
    {
        isCharging = true;
        chargeTimer = 0.0f;
        cooldownTimer = cooldownTime;
    }

    void ReleaseAttack()
    {
        if (isCharging)
        {
            swing = Instantiate(swingPre, hand.transform.position, hand.transform.rotation);
            Rigidbody2D swingrb = swing.GetComponent<Rigidbody2D>();

            swingrb.AddForce(swing.transform.right * swingspeed, ForceMode2D.Impulse);

            // Add a component to destroy the swing after 3 seconds
            Destroy(swing, 3f);

            isCharging = false;
        }
    }

    void RotateHandPivotTowardsMouse()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Set the z-coordinate to 0, assuming your game is in 2D

        // Calculate the direction towards the mouse
        Vector3 direction = mousePosition - handpivot.transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate handpivot towards the mouse
        handpivot.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the object you want to destroy the swing on
        if (collision.gameObject.CompareTag("YourTag")) // Replace "YourTag" with the actual tag of the object
        {
            // Destroy the swing
            Destroy(swing.gameObject);
        }
    }
}
