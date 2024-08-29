using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float playerSpeed = 10f;
    float hor;
    float vert;
    float slashCooldown = 1.5f;
    float lastSlashTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input for movement
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            {
                // Check if cooldown is up
                if (Time.time - lastSlashTime >= slashCooldown)
                {
                    SlashSword();
                    lastSlashTime = Time.time;  // Reset cooldown
                }
            }
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = new Vector3(hor * playerSpeed, 0, vert * playerSpeed);

        // Apply facing
        FaceCursor();
    }

    void FaceCursor()
    {
        /* Lot of complex stuff here I don't fully understand
        * https://discussions.unity.com/t/make-a-player-model-rotate-towards-mouse-location/125354
        */

        // Convert the object's position to screen space
        Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Get the cursor position in screen space
        Vector3 cursorScreenPosition = Input.mousePosition;

        // Calculate the direction vector from the object to the cursor
        Vector3 direction = cursorScreenPosition - objectScreenPosition;

        // Invert the y-axis direction to fix top/bottom inversion issue
        direction.y = -direction.y;

        // Calculate the angle to rotate the object towards the cursor
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Calculate the current angle
        float currentAngle = transform.rotation.eulerAngles.y;

        // Calculate the angle difference and clamp it
        float angleDifference = Mathf.DeltaAngle(currentAngle, angle);
        float maxRotationStep = 360f * Time.deltaTime;
        float clampedAngleDifference = Mathf.Clamp(angleDifference, -maxRotationStep, maxRotationStep);

        // Apply the clamped rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, currentAngle + clampedAngleDifference, 0f));
    }

    void SlashSword()
    {
        // Create cube
        GameObject sword = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Size the cube like a sword
        sword.transform.localScale = new Vector3(1.5f, .1f, 0.1f);

        // Child the cube to the player
        sword.transform.SetParent(transform);

        // Position the sword in front of the player using the player's forward direction to position the sword
        sword.transform.localPosition = new Vector3 (1.5f, 0f, 0f);

        // Rotate the sword to be facing the correct way
        sword.transform.rotation = Quaternion.LookRotation(transform.forward);

        // Destroy the sword after a third of a second
        Destroy(sword, 0.33f);
    }
}
