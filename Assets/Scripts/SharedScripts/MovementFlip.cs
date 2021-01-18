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
        if (rb.velocity.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
        else if (rb.velocity.x > 0.1f )
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
    }


}