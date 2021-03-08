public interface IMovement
{
	void SetMovementSpeedByAddition(float number);

	void SetMovementSpeedModifierToDefault();

	void SetLockXMovement(bool isLocked);

	float GetMovementSpeed();

	float GetMovementSpeedModifier();
}