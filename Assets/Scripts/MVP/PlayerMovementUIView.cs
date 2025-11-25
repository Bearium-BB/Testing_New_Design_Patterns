using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementUIView : MonoBehaviour, IPlayerMovementUIView
{
    [Inject] private IUIService service;

    public event Action<Vector2> OnMoveInput;

    public void UpdateUI(Vector3 velocity)
    {
        service.SetText("PLAYER_UI", "velocityMVP", velocity.ToString());
    }
}
