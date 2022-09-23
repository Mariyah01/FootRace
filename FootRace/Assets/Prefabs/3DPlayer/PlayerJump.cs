using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Jump height
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;

    private bool canJump;


    // Start is called before the first frame update
    private void Start()
    {
        //Player's RigidBody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Creates a Linecast connecting from the player to the groundCheck Transform, checking for the groundLayer
        bool grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);

        // Visually draws a red line in place of the Linecast
        Debug.DrawLine(transform.position, groundCheck.position, Color.red);

        // Determines when the player is allowed to jump based on whether the Linecast detects the groundLayer or not
        if (grounded == true)
            canJump = true;
        else
            canJump = false;

        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
