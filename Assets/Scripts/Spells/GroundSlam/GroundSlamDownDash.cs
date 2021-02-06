using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlamDownDash : MonoBehaviour
{
    [SerializeField]
    private float forceY = 0;
    private Rigidbody2D playerRigidBody;
    private PlayerJump playerJump;

    private bool wasGrounded;

    void Awake()
    {
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();

        playerRigidBody.AddForce(new Vector2(0, forceY));

    }



}
