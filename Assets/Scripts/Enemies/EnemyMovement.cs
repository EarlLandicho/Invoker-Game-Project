using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float movementSpeed = 0;

    private float movementSpeedTemp = 0;

    private void Awake()
    {
        movementSpeedTemp = movementSpeed;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void SetMovementSpeedByFactor(float factor)
    {
        movementSpeed *= factor;
    }

    public void SetSpeedToDefault()
    {
        movementSpeed = movementSpeedTemp;
    }

    public void LockMovement()
    {
        //movementSpeed = 0;
    }

    public void UnlockMovement()
    {
        //movementSpeed = movementSpeedTemp;
    }
}