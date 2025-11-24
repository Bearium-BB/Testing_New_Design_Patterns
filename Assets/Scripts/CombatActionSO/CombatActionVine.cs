using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "Vine", menuName = "Combat Action/Vine", order = 1)]
public class CombatActionVine : CombatActionTimerSO
{
    public float force = 1f;
    public float dist = 5f;
    public float damage = 5;
    public LayerMask canHit;

    public override void CallAction(CombatActionDataMB data)
    {
        if (data is CombatActionDataVine)
        {
            if (!isOnCooldown)
            {
                CombatActionDataVine dataVine = (CombatActionDataVine)data;
                Vector3 dir = dataVine.mousePosition - dataVine.rb.transform.position;
    
                RaycastHit2D hit  = Physics2D.Raycast(dataVine.rb.transform.position, dir, dist, canHit);

                if (hit)
                {
                    //hit.collider.transform.TryGetComponent(out Health health);
                    //if(health)
                    //{
                    //    health.TakeDamage(damage);
                    //}
                    dataVine.rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);
                    StartCooldown();
                }
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
        return typeof(CombatActionDataVine);
    }
}
