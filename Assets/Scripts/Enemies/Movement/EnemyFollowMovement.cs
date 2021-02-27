using UnityEngine;

public class EnemyFollowMovement : EnemyMovement
{
    private void FixedUpdate()
    {
        if (!isXMovementSpeedLocked)
        {
            Vector2 playerDirection = ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject);

            rb.velocity = playerDirection * movementSpeed;
        }
    }

    public override void SetLockXMovement(bool isLocked)
    {
        isXMovementSpeedLocked = isLocked;
        if (isLocked)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            movementSpeed = movementSpeedTemp * movementSpeedModifier;
        }
    }
}