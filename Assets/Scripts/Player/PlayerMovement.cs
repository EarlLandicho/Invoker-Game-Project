using UnityEngine;

public class PlayerMovement : Movement
{
    private bool isFlying;

    private void Update()
    {
        MoveCheck();
    }

    public void SetIsFlying(bool isFlying)
    {
        this.isFlying = isFlying;
    }

    private void MoveCheck()
    {
        if(!isXMovementSpeedLocked && !isFlying)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed * movementSpeedModifier, rb.velocity.y);
        }
        else if(isFlying)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * movementSpeedModifier, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * movementSpeed * movementSpeedModifier);
        }
    }

    
}