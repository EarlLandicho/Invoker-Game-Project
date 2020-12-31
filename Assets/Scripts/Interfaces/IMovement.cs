public interface IMovement
{
    void SetMovementSpeedByFactor(float factor);

    void SetSpeedToDefault();

    void LockMovement(float duration);
}