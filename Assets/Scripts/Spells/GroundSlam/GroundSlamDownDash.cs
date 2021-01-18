using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlamDownDash : MonoBehaviour
{
    [SerializeField]
    private float forceY = 0;
    private Rigidbody2D playerRigidBody;

    void Awake()
    {
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        playerRigidBody.AddForce(new Vector2(0, forceY));

    }



}
