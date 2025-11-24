using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class PlayerPresenter
{
    IPlayerMovementView playerMovementView;
    IPlayerMovementUIView playerMovementUIView;
    IPlayerMovementDebugView playerMovementDebugView;
    PlayerModel playerModel;

    public PlayerPresenter(IPlayerMovementView playerMovementView, IPlayerMovementUIView playerMovementUIView, IPlayerMovementDebugView playerMovementDebugView, PlayerModel playerModel)
    {
        this.playerMovementView = playerMovementView;
        this.playerMovementUIView = playerMovementUIView;
        this.playerMovementDebugView = playerMovementDebugView;
        this.playerModel = playerModel;

        playerMovementView.OnMoveInput += HandleMoveInput;
    }

    private void HandleMoveInput(Vector2 input)
    {

        Vector3 velocity = playerModel.CalculateMovement(input);
        playerMovementView.ApplyMovement(velocity);
        playerMovementUIView.UpdateUI(velocity);
        playerMovementDebugView.SentDebug(velocity);
    }

    //private void HandleMoveUI(Vector2 input)
    //{

    //    Vector3 velocity = playerModel.CalculateMovement(input);
    //    playerMovementUIView.UpdateUI(velocity);

    //}

    //private void HandleMoveDebug(Vector2 input)
    //{
    //    Vector3 velocity = playerModel.CalculateMovement(input);
    //    playerMovementDebugView.SentDebug(velocity);
    //}
}
