using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI velocityText;
    [SerializeField] private TextMeshProUGUI magnitudeVelocityText;

    public void Bind(PlayerViewModel vm)
    {
        vm.playerModel.velocity.OnValueChanged += v => UpdateVelocity(v);
        vm.magnitude.OnValueChanged += m => UpdateMagnitude(m);

        UpdateVelocity(vm.playerModel.velocity.Value);
        UpdateMagnitude(vm.magnitude.Value);

    }

    public void UpdateVelocity(Vector3 vector3)
    {
        velocityText.text = vector3.ToString();
    }

    public void UpdateMagnitude(float magnitude)
    {
        magnitudeVelocityText.text = magnitude.ToString();
    }
}
