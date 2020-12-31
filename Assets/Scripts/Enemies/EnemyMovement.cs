using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float movementSpeed = 0;

    private float movementSpeedTemp = 0;

    void Awake()
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

    public void LockMovement(float duration)
    {
        StopCoroutine("Lock");
        StartCoroutine("Lock", duration);
    }

    private IEnumerator Lock(float duration)
    {
        movementSpeed = 0;
        yield return new WaitForSeconds(duration);
        movementSpeed = movementSpeedTemp;
    }
}
