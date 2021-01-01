using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    [SerializeField]
    private float movementSpeed = 5;

    private float movementSpeedTemp;
    private bool isLocked = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        movementSpeedTemp = movementSpeed;
    }

    private void Update()
    {
        MoveCheck();
    }

    public void SetMovementSpeedByFactor(float factor)
    {
        movementSpeed *= factor;
    }

    public void SetSpeedToDefault()
    {
        if (!isLocked)
        {
            movementSpeed = movementSpeedTemp;

        }
    }

    public void LockMovement()
    {
        isLocked = true;
        rb.velocity = new Vector2(0, 0);
    }

    public void UnlockMovement()
    {
        isLocked = false;
        movementSpeed = movementSpeedTemp;
    }

    private void MoveCheck()
    {
        if(!isLocked)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rb.velocity.y);

        }
    }
}