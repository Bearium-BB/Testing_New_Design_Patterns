using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDebugView :  MonoBehaviour, IPlayerMovementDebugView
{
    public event Action<Vector2> OnMoveInput;

    public void SentDebug(Vector3 velocity)
    {
        //Debug.Log(velocity);
    }

}
