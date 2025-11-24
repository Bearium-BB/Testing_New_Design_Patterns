using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaterSurge", menuName = "Combat Action/Water Surge", order = 1)]
public class CombatActionWaterSurge : CombatActionTimerSO
{

    public float jumpForce = 1f;

    public override void CallAction(CombatActionDataMB data)
    {
        if (data is CombatActionDataRigidbody2D)
        {
            if (!isOnCooldown)
            {
                CombatActionDataRigidbody2D dataVine = (CombatActionDataRigidbody2D)data;

                Vector2 velocity = dataVine.rb.velocity;
                velocity.y = 0;
                dataVine.rb.velocity = velocity;

                float jumpVelocity = Mathf.Sqrt(2 * jumpForce * -Physics2D.gravity.y);
                dataVine.rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                StartCooldown();
            }
        }
        else
        {

        }
    }

    public override void UpdateAction(CombatActionDataMB data)
    {
        base.UpdateAction(data);

    }


    public override Type GetTypeCombatActionDataMB()
    {
        return typeof(CombatActionDataRigidbody2D);
    }
}
