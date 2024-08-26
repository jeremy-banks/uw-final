using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float playerSpeed;
    float hor;
    float vert;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(hor * playerSpeed, vert * playerSpeed, 0);
    }
}
