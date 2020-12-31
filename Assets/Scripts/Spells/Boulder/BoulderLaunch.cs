using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoulderLaunch : MonoBehaviour
{
    [SerializeField] private float speedX = 0;
    [SerializeField] private float upwardForce = 0;
    [SerializeField] private float speedY = 0;

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
            rb.velocity = transform.up * speedY;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.up * speedY;

            playerJump.Jump();
        }
        else
        {
            rb.velocity = transform.right * speedX;
            rb.AddForce(new Vector2(0, upwardForce));
        }
    }
}