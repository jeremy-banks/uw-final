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

        //get input for movement
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //apply movement
        rb.velocity = new Vector3(hor * playerSpeed, vert * playerSpeed, 0);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
