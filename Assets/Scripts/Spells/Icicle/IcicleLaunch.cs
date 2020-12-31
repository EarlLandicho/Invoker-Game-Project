using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleLaunch : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    private Rigidbody2D rb;
    private PlayerJump playerJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
    }

    private void Start()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.up * speed;

            playerJump.Jump();
        }
        else
        {
            rb.velocity = transform.right * speed;
        }

    }
}
