using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand;
    public GameObject handpivot;
    public Transform spawnPoint;
    public GameObject swingPre;
    public float chargeTime = 2.0f;
    public int swingspeed = 30;
    public float cooldownTime = 1.0f;
    public GameObject sword1;
    public GameObject sword2;
    public GameObject Swords;

    private float cooldownTimer = 0.0f;
    private GameObject swing;

    private void Start()
    {
        // Ensure sword1 is not null before setting its parent and position
        if (sword1 != null)
        {
            sword1.transform.parent = hand.transform;
            sword1.transform.position = hand.transform.position;
        }
    }

    void Update()
    {
        // Update cooldown timer
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Check for mouse input and cooldown before releasing an attack
        if (Input.GetMouseButtonDown(0) && cooldownTimer <= 0)
        {
            ReleaseAttack();
        }

        // Rotate hand pivot towards mouse
        RotateHandPivotTowardsMouse();

        // Adjust sword rotation based on handpivot rotation
        if (handpivot.transform.rotation.eulerAngles.z < 0)
        {
            // Ensure sword1 is not null before adjusting its rotation
            if (sword1 != null)
            {
                sword1.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
    }

    public void Equippowerup(int num)
    {
        switch (num)
        {
            case 0:
                // Ensure sword1 is not null before changing its parent and position
                if (sword1 != null)
                {
                    sword1.transform.parent = Swords.transform;
                    sword1.transform.position = Swords.transform.position;
                    sword2.transform.parent = hand.transform;
                    sword2.transform.position = hand.transform.position;

                    swing.GetComponent<swing>().damageAmount += 5;

                }
                return;
            case 1:
                gameObject.GetComponent<PlayerMovement>().speed += 3.0f;
                return;
            case 2:
                swing.GetComponent<swing>().damageAmount += 5;
                return;
        }
    }

    void ReleaseAttack()
    {
        // Instantiate the swingPre at hand position and rotation
        swing = Instantiate(swingPre, hand.transform.position, hand.transform.rotation);
        Rigidbody2D swingrb = swing.GetComponent<Rigidbody2D>();

        // Apply force to the swing object
        swingrb.AddForce(swing.transform.right * swingspeed, ForceMode2D.Impulse);

        // Destroy the swing object after 1 second
        Destroy(swing, 1f);

        // Set cooldown timer
        cooldownTimer = cooldownTime;
    }

    void RotateHandPivotTowardsMouse()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calculate the direction from handpivot to the mouse
        Vector3 direction = mousePosition - handpivot.transform.position;

        // Calculate the angle in degrees and set the rotation of handpivot
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        handpivot.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
