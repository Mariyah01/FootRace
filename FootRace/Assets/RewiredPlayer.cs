using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class RewiredPlayer : MonoBehaviour
{
    private Player player;

    private Rigidbody _rigidbody;

    private int speed = 15;

    [SerializeField] private int playerID;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        Vector3 movement = new Vector3(player.GetAxis("MoveX") * speed, _rigidbody.velocity.y,
            player.GetAxis("MoveY") * speed);
        _rigidbody.velocity = movement;
        
        //Player something, like fire
        if (player.GetButtonDown("Something"))
        {
            print("Controller working!");
        }
        
    }
}
