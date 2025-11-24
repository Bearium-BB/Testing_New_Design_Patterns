using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovementDebugView
{
    event Action<Vector2> OnMoveInput;
    void SentDebug(Vector3 velocity);
}
