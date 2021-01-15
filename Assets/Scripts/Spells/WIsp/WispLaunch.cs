using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispLaunch : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.up * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
            Debug.Log(rb.velocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

}
