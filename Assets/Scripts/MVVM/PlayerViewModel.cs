using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewModel
{

    public PlayerModel playerModel;
    public ObservableProperty<float> magnitude = new ObservableProperty<float>();

    public PlayerViewModel(PlayerModel playerModel)
    {
        this.playerModel = playerModel;
        playerModel.velocity.OnValueChanged += v => magnitude.Value = v.magnitude;
    }

}
