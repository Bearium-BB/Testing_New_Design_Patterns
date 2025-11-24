using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovementUIView
{
    event Action<Vector2> OnMoveInput;
    void UpdateUI(Vector3 velocity);
}
