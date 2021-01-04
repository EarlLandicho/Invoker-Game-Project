using UnityEngine;

public class PlayerJump : MonoBehaviour, IJump
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundLayer;

    private float jumpHeightTemp;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform groundCheck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");

        jumpHeightTemp = jumpHeight;
    }

    private void FixedUpdate()
    {
        JumpAbleCheck();
    }

    private void Update()
    {
        JumpCheck();
    }

    public void SetLockJump(bool isLocked)
    {
        //this.isLocked = isLocked;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public void Jump()
    {
        rb.velocity = transform.up * jumpHeight;
    }

    public void SetJumpHeightByFactor(float factor)
    {
        jumpHeight *= factor;
    }

    public void SetJumpHeightToDefault()
    {
        jumpHeight = jumpHeightTemp;
    }

    private void JumpAbleCheck()
    {
        if (Physics2D.OverlapCircle(new Vector2(groundCheck.position.x, groundCheck.position.y), 0.05f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
    }
}