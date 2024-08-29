using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // https://discussions.unity.com/t/make-a-player-model-rotate-towards-mouse-location/125354

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
        FaceCursor();

        //get input for movement
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            {
                // Check if enough time has passed since the last sword
                if (Time.time - lastSlashTime >= slashCooldown)
                {
                    SlashSword();
                    lastSlashTime = Time.time;  // Update the time of the last sword creation
                }
            }
        }
    }

    void FixedUpdate()
    {
        //apply movement
        rb.velocity = new Vector3(hor * playerSpeed, vert * playerSpeed, 0);
    }

    void FaceCursor()
    {
        //idk what any of this does thx google
        //https://discussions.unity.com/t/make-a-player-model-rotate-towards-mouse-location/125354

        //transform position from world space into viewport space
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //transform position from screen space into viewport space
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //get angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //calculate the current angle
        float currentAngle = transform.rotation.eulerAngles.z;

        //calculate the angle difference and clamp it
        float angleDifference = Mathf.DeltaAngle(currentAngle, angle);
        float maxRotationStep = 360f * Time.deltaTime;
        float clampedAngleDifference = Mathf.Clamp(angleDifference, -maxRotationStep, maxRotationStep);

        //apply the clamped rotation
        transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, currentAngle + clampedAngleDifference));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void SlashSword()
    {
        //create cube
        GameObject sword = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //size the cube like a sword
        sword.transform.localScale = new Vector3(0.1f, 1.5f, 0.3f);

        //position the sword in front of the player
        sword.transform.position = transform.position + transform.forward;
    }
}
