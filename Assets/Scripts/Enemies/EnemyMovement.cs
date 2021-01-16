using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float movementSpeed = 0;

    private float movementSpeedTemp = 0;
    //private bool isLocked = false;

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

    public void SetLockXMovement(bool isLocked)
    {
        if(isLocked)
        {
            movementSpeed = 0;
        }
        else
        {
            movementSpeed = movementSpeedTemp;
        }
        
    }

    public void SetMovementSpeedByFactor(float factor, bool isSetting)
    {
        throw new System.NotImplementedException();
    }

    public float GetMovementSpeedModifier()
    {
        throw new System.NotImplementedException();
    }

    public void SetMovementSpeedModifierToDefault()
    {
        throw new System.NotImplementedException();
    }
}