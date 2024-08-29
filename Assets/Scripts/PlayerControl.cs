using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // https://discussions.unity.com/t/make-a-player-model-rotate-towards-mouse-location/125354

    Rigidbody rb;
    [SerializeField] float playerSpeed = 10f;
    float hor;
    float vert;

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
            SlashSword();
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

        //Transforms position from world space into viewport space.
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Transforms position from screen space into viewport space.
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        // Calculate the current angle
        float currentAngle = transform.rotation.eulerAngles.z;

        // Calculate the angle difference and clamp it
        float angleDifference = Mathf.DeltaAngle(currentAngle, angle);
        float maxRotationStep = 360f * Time.deltaTime;
        float clampedAngleDifference = Mathf.Clamp(angleDifference, -maxRotationStep, maxRotationStep);

        // Apply the clamped rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAngle + clampedAngleDifference));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void SlashSword()
    {
        // Create a new GameObject
        GameObject sword = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Set the name of the object
        sword.name = "Sword";

        // Set the size of the sword
        sword.transform.localScale = new Vector3(0.1f, 1.5f, 0.3f);

        // Add a collider to the sword (BoxCollider is already added by GameObject.CreatePrimitive)
        BoxCollider boxCollider = sword.GetComponent<BoxCollider>();

        // Optionally adjust collider if needed
        // boxCollider.size = swordSize;

        // Optionally, adjust the position of the sword relative to the player
        sword.transform.position = transform.position + transform.forward;  // Position in front of the player
    }
}
