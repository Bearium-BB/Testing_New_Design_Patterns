using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstaller : MonoBehaviour
{
    public PlayerView playerView;
    public PlayerMovementUIView playerMovementUIView;
    public PlayerMovementDebugView playerMovementDebugView;
    public PlayerUIView playerUIView;
    public PlayerMovementDebugViewMVVM playerMovementDebugViewMVVM;

    public float moveSpeed = 5f;

    private void Start()
    {
        PlayerModel model = new PlayerModel(moveSpeed);
        PlayerViewModel playerViewModel = new PlayerViewModel(model);
        playerUIView.Bind(playerViewModel);
        playerMovementDebugViewMVVM.Bind(playerViewModel);
        PlayerPresenter presenter = new PlayerPresenter(playerView, playerMovementUIView, playerMovementDebugView, model);
    }
}
