using UnityEngine;

public class WispLaunch : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private bool isDownDirection;
    private bool isUpDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.W))
        {
            isUpDirection = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isDownDirection = true;
        }
    }

    private void Update()
    {
        if (isDownDirection)
        {
            rb.velocity = -transform.up * speed;
        }
        else if (isUpDirection)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
    }
}