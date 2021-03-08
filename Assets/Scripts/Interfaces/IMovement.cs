public interface IMovement
{
	void SetMovementSpeedByFactor(float factor, bool isSetting);

	void SetMovementSpeedModifierToDefault();

	void SetLockXMovement(bool isLocked);

	float GetMovementSpeed();

	float GetMovementSpeedModifier();
}