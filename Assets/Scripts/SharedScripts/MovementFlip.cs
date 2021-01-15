using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementFlip : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FlipCheck();
    }

    public bool GetIsFacingRight()
    {
        return facingRight;
    }

    private void FlipCheck()
    {
        if (rb.velocity.x < -0.1f && facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x > 0.1f && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}