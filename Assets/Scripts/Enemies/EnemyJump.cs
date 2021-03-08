#region

using System;
using UnityEngine;

#endregion

//implement when there is a jumping enemy
public class EnemyJump : MonoBehaviour, IJump
{
	public void SetJumpHeightByFactor(float factor)
	{
		throw new NotImplementedException();
	}

	public void SetJumpHeightToDefault()
	{
		throw new NotImplementedException();
	}

	public void SetLockJump(bool isLocked)
	{
		throw new NotImplementedException();
	}
}