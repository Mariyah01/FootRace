using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    // How fast the Player will move
    [SerializeField] private float speed;

    // The Player's Rigidbody component
    private Rigidbody rb;
    
    //The player's rotation value
    private float facing;

    // Start is called before the first frame update
    private void Start()
    {
        // Directly grabs the Player's Rigidbody and plugs it in as "rb"
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Creates values out of our inputs multiplied by the amount of speed we set
        float xMovement = Input.GetAxis("Horizontal2") * speed;
        float zMovement = Input.GetAxis("Vertical2") * speed;

        // Vector3 values made up of our input values
        Vector3 movement = new Vector3(xMovement, 0, zMovement);

        // Generates movement in the Player's Rigidbody using the Vector3 values from above
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (movement.x != 0 || movement.z != 0)
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        
        rb.rotation=Quaternion.Euler(0,facing,0);
    }
}
