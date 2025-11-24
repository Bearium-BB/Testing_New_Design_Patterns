using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamCloud", menuName = "Combat Action/Steam Cloud", order = 1)]
public class CombatActionSteamCloud : CombatActionTimerSO
{
    public float dist = 5;
    public LayerMask dashCantThrough;
    public LayerMask canDamage;
    public float damage = 5;

    public float size = 1;

    public override void CallAction(CombatActionDataMB data)
    {
        if (data is CombatActionDataTransform)
        {
            if (!isOnCooldown)
            {
                CombatActionDataTransform dataTransform = (CombatActionDataTransform)data;

                Transform t = dataTransform.transformData;

                Vector3 pos = t.position;
                Vector3 dir = t.right;

                float h = size;
                float half = h * 0.5f;

                float feetOffset = -half * 0.9f;
                float lowMidOffset = -half * 0.45f;
                float midOffset = 0f;
                float upperMidOffset = half * 0.45f;
                float headOffset = half * 0.9f;

                Vector3 originFeet = pos + new Vector3(0, feetOffset, 0);
                Vector3 originLowMid = pos + new Vector3(0, lowMidOffset, 0);
                Vector3 originMid = pos + new Vector3(0, midOffset, 0);
                Vector3 originUpperMid = pos + new Vector3(0, upperMidOffset, 0);
                Vector3 originHead = pos + new Vector3(0, headOffset, 0);

                RaycastHit2D hitFeet = Physics2D.Raycast(originFeet, dir, dist, dashCantThrough);
                RaycastHit2D hitLowMid = Physics2D.Raycast(originLowMid, dir, dist, dashCantThrough);
                RaycastHit2D hitMid = Physics2D.Raycast(originMid, dir, dist, dashCantThrough);
                RaycastHit2D hitUpperMid = Physics2D.Raycast(originUpperMid, dir, dist, dashCantThrough);
                RaycastHit2D hitHead = Physics2D.Raycast(originHead, dir, dist, dashCantThrough);

                Debug.DrawRay(originFeet, dir * dist, Color.yellow, 2);
                Debug.DrawRay(originLowMid, dir * dist, Color.yellow, 2);
                Debug.DrawRay(originMid, dir * dist, Color.yellow, 2);
                Debug.DrawRay(originUpperMid, dir * dist, Color.yellow, 2);
                Debug.DrawRay(originHead, dir * dist, Color.yellow, 2);

                // Determine nearest hit (if any)
                RaycastHit2D finalHit = GetClosestHit(hitFeet, hitLowMid, hitMid, hitUpperMid, hitHead);

                if (finalHit)
                {
                    float mag = Vector3.Distance(new Vector3(pos.x, 0, 0), new Vector3(finalHit.point.x, 0, 0));
                    t.Translate(new Vector3(mag - (size * 0.5f), 0, 0), Space.Self);
                }
                else
                {
                    t.Translate(new Vector3(dist, 0, 0), Space.Self);
                }

                RaycastHit2D[] hits = Physics2D.RaycastAll(pos, dir, dist, canDamage);
                Debug.Log(hits.Length);
                foreach (RaycastHit2D hitEntity in hits)
                {
                    //hitEntity.collider.transform.TryGetComponent(out Health health);
                    //if (health)
                    //{
                    //    health.TakeDamage(damage);
                    //}
                }

                StartCooldown();
            }
        }
        else
        {
            Debug.Log($"Incorrect data type for CombatActionData: {data.GetType()}");
        }
    }

    // Picks the nearest hit among the five
    private RaycastHit2D GetClosestHit(params RaycastHit2D[] hits)
    {
        RaycastHit2D closest = new RaycastHit2D();
        float closestDist = float.MaxValue;

        foreach (var h in hits)
        {
            if (h.collider != null)
            {
                float d = h.distance;
                if (d < closestDist)
                {
                    closestDist = d;
                    closest = h;
                }
            }
        }

        return closest;
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
