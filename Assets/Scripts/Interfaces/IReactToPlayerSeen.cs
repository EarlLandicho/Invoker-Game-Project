using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReactToPlayerSeen
{
    void ReactToPlayerSeen(GameObject player);
    void ReactToPlayerNoLongerSeen();
}
