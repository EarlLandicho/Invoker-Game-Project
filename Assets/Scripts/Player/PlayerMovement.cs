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

    public void SetLockMovement(bool isLocked)
    {
        this.isLocked = isLocked;
        if (isLocked)
        {
            
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            movementSpeed = movementSpeedTemp;
        }
        
    }


    private void MoveCheck()
    {
        if(!isLocked)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rb.velocity.y);

        }
    }
}