using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJump
{
    void SetJumpHeightByFactor(float factor);
    void SetJumpHeightToDefault();
}
