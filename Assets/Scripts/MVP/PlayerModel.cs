using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public float moveSpeed { get; private set; }
    //public Vector3 velocity { get; private set; }

    public ObservableProperty<Vector3> velocity { get; private set; }


    public PlayerModel(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
        this.velocity = new ObservableProperty<Vector3>();
        this.velocity.Value = Vector3.zero;
    }


    public Vector3 CalculateMovement(Vector2 input)
    {
        velocity.Value = new Vector3(input.x, 0, input.y) * moveSpeed;
        return velocity.Value;
    }

}
