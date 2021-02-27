using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour, IMovement
{
    [SerializeField]
    protected float movementSpeed;

    protected float movementSpeedTemp;
    protected bool isXMovementSpeedLocked = false;
    protected float movementSpeedModifier = 1;

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        movementSpeedTemp = movementSpeed;
    }

    public virtual float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public virtual float GetMovementSpeedModifier()
    {
        return movementSpeedModifier;
    }

    public virtual void SetLockXMovement(bool isLocked)
    {
        isXMovementSpeedLocked = isLocked;
        if (isLocked)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            movementSpeed = movementSpeedTemp * movementSpeedModifier;
        }
    }

    public virtual void SetMovementSpeedByFactor(float factor, bool isSetting)
    {
        if (isSetting)
        {
            movementSpeedModifier *= factor;
            Debug.Log("movement modifier set to" + movementSpeedModifier);
        }
        else
        {
            movementSpeedModifier /= factor;
            Debug.Log("movement modifier reset to " + movementSpeedModifier);
        }
    }

    public virtual void SetMovementSpeedModifierToDefault()
    {
        movementSpeedModifier = 1;
    }
}