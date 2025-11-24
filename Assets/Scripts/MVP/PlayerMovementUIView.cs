using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementUIView : MonoBehaviour, IPlayerMovementUIView
{
    public TextMeshProUGUI textBox;
    public event Action<Vector2> OnMoveInput;

    public void UpdateUI(Vector3 velocity)
    {
        textBox.text = velocity.ToString();
    }
}
