using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    //camera
    [SerializeField] private Transform cameraTarget;

    //mouse look/move
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private bool InvertMouse = false;
    [SerializeField] private float LookUpConstraint = 60f;
    [SerializeField] private float LookDownConstraint = -60f;

    //movement
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float runSpeed = 15f;
    
    //jumping    
    // [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float gravityMod = 2.5f;
    // [SerializeField] private Transform groundCheck;
    // [SerializeField] private LayerMask groundLayers;


    //local GameObjects
    private CharacterController charController;
    [SerializeField] private Camera Camera;


    //local variables
    private float verticalRotationStore;
    private Vector3 movement;
    // private bool isGrounded;

    //Rewire
    private Player player;
    [SerializeField] private int playerID;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        player = ReInput.players.GetPlayer(playerID);
    }

    void Update()
    {
        //mouse input
        Vector2 mouseInput = new Vector2(player.GetAxis("LookX"), player.GetAxis("LookY")) * mouseSensitivity;

        //rotate character based on x mouse movement
        float yRotation = transform.rotation.eulerAngles.y + mouseInput.x;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);


        //mouse invert preference multiplier
        float invert = (!InvertMouse) ? -1f : 1f;
        verticalRotationStore += (mouseInput.y * invert);

        //limit X rotation value based on input
        verticalRotationStore = Mathf.Clamp(verticalRotationStore, LookDownConstraint, LookUpConstraint);

        //apply rotation to camera target
        cameraTarget.rotation = Quaternion.Euler(verticalRotationStore, cameraTarget.eulerAngles.y, cameraTarget.eulerAngles.z);

        //get user input for moving
        Vector3 movement = new Vector3(player.GetAxis("MoveX") * moveSpeed, charController.velocity.y,player.GetAxis("MoveY") * moveSpeed);

        //apply gravity to the player
        movement.y += Physics.gravity.y * Time.deltaTime * gravityMod;

        //apply movement to the player
        charController.Move(movement * Time.deltaTime);

    }

    private void LateUpdate()
    {
        //change main camera position and rotation based on cameraTarget
        Camera.transform.position = cameraTarget.position;
        Camera.transform.rotation = cameraTarget.rotation;
    }
}
