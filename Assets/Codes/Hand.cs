using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand;
    public GameObject handpivot;
    public Transform spawnPoint;
    public float chargeTime = 2.0f;

    private bool isCharging = false;
    private float chargeTimer = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCharge();
        }

        if (Input.GetKeyUp(KeyCode.Space))
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
    }

    void ReleaseAttack()
    {
        if (isCharging)
        {

            GameObject Hand = Instantiate(hand, spawnPoint.position, spawnPoint.rotation);
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

}
