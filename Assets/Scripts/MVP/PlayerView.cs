using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour, IPlayerMovementView
{
    public float inputDeadZone = 0.1f;

    public event Action<Vector2> OnMoveInput;

    private Rigidbody rb;
    private Vector3 currentVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v);

        if (input.magnitude > inputDeadZone)
        {
            OnMoveInput?.Invoke(input.normalized);
        }
        else
        {
            OnMoveInput?.Invoke(Vector2.zero);
        }
    }

    public void ApplyMovement(Vector3 velocity)
    {
        currentVelocity = velocity;
    }

    private void FixedUpdate()
    {
        rb.velocity = currentVelocity;
    }
}
