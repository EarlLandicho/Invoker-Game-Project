using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    [SerializeField]
    private float movementSpeed = 5;
    private float movementSpeedTemp;

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
        movementSpeed = movementSpeedTemp;
    }

    public void LockMovement(float duration)
    {

    }

    private void MoveCheck()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rb.velocity.y);
    }
}