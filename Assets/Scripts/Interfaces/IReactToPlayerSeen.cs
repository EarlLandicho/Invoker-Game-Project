using UnityEngine;

public interface IReactToPlayerSeen
{
    void ReactToPlayerSeen(GameObject player);

    void ReactToPlayerNoLongerSeen();
}