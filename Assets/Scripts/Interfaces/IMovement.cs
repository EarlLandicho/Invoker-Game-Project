using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void SetMovementSpeedByFactor(float factor);
    void SetSpeedToDefault();
    void LockMovement(float duration);
}
