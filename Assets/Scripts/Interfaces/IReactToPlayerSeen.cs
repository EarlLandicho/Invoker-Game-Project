#region

using UnityEngine;

#endregion

public interface IReactToPlayerSeen
{
	void ReactToPlayerSeen(GameObject player);

	void ReactToPlayerNoLongerSeen();
}