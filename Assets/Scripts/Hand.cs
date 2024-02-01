using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand;
    public GameObject handpivot;
    public float smooth = 200.0f;
    private Camera mainCamera;
    private Transform handPivotTransform;
    public GameObject slashpf;
    private Transform bulletSpawnPoint;
    public int bulletSpeed;
    private Vector3 mousePressPosition;
    private Vector3 middlePosition;

    void Start()
    {
        mainCamera = Camera.main;
        handPivotTransform = handpivot.transform;
        bulletSpawnPoint = hand.transform; // Use handpivot instead of transform
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePressPosition = hand.transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouseReleasePosition = hand.transform.position;
            middlePosition = (mousePressPosition + mouseReleasePosition) / 2f;
            Slash();
        }
        else
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = mainCamera.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            handPivotTransform.rotation = Quaternion.RotateTowards(handPivotTransform.rotation, targetRotation, smooth * 100 * Time.fixedDeltaTime);
        }
    }

    void Slash()
    {
        Vector3 worldMiddlePosition = mainCamera.ScreenToWorldPoint(new Vector3(middlePosition.x, middlePosition.y, mainCamera.nearClipPlane));
        GameObject slash = Instantiate(slashpf, worldMiddlePosition, handPivotTransform.rotation);

        Rigidbody2D slashRb = slash.GetComponent<Rigidbody2D>();
        slashRb.velocity = slash.transform.right * bulletSpeed; // Use slash.transform.right instead of bulletSpawnPoint.forward
    }
}
