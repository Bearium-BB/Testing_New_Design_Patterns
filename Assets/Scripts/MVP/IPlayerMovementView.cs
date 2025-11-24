using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovementView
{
    event Action<Vector2> OnMoveInput;
    void ApplyMovement(Vector3 velocity);
}
