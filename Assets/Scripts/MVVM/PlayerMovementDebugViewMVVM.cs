using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDebugViewMVVM : MonoBehaviour
{
    public void Bind(PlayerViewModel vm)
    {
        Debug.Log(vm.playerModel.velocity.Value);
        vm.playerModel.velocity.OnValueChanged += v => Debug.Log(vm.playerModel.velocity.Value);
    }
}
