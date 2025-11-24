using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnProjectile", menuName = "Combat Action/Spawn Projectile", order = 1)]
public class CombatActionSpawnProjectile : CombatActionTimerSO
{
    public float jumpForce = 1f;
    public GameObject projectile;
    public Vector3 offSet;
    public bool setRotationOfPlayer;

    public override void CallAction(CombatActionDataMB data)
    {
        if (data is CombatActionDataTransform)
        {
            if (!isOnCooldown)
            {
                CombatActionDataTransform dataVine = (CombatActionDataTransform)data;
                Transform t = dataVine.transformData;

                Vector3 directionAdjustedOffset = offSet;

                if (Mathf.Abs(t.eulerAngles.y - 180f) < 1f)
                {
                    directionAdjustedOffset.x *= -1f;
                }

                Vector3 spawnPosition = t.position + directionAdjustedOffset;

                GameObject spawnGameObject = Instantiate(projectile, spawnPosition, t.rotation);
                if (setRotationOfPlayer)
                {
                    spawnGameObject.transform.rotation = dataVine.transform.rotation;
                }
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
        return typeof(CombatActionDataTransform);
    }
}
