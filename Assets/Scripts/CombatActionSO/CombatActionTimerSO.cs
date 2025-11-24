using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatActionTimerSO : CombatActionSO
{
    public string abilityName;
    public string description;
    public Sprite icon;

    public float cooldown = 2f;
    private float elapsedTime;
    protected bool isOnCooldown;

    public override void UpdateAction(CombatActionDataMB data)
    {
        if (isOnCooldown)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= cooldown)
            {
                isOnCooldown = false;
                elapsedTime = 0f;
            }
        }
    }


    public float TimerPercentage()
    {
        return elapsedTime / cooldown;
    }

    public void StartCooldown()
    {
        isOnCooldown = true;
        elapsedTime = 0f;
    }

    public bool GetIsOnCooldown()
    {
        return isOnCooldown;
    }

    private void OnEnable()
    {
        isOnCooldown = false;
        elapsedTime = 0;
    }

    private void OnDisable()
    {
        isOnCooldown = false;
        elapsedTime = 0;
    }


}
