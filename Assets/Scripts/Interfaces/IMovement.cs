public interface IMovement
{
    void SetMovementSpeedByFactor(float factor);

    void SetSpeedToDefault();

    void SetLockMovement(bool isLocked);

    float GetMovementSpeed();

}