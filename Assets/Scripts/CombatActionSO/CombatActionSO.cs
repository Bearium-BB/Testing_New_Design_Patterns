using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatActionSO : ScriptableObject, ICombatAction
{
    public abstract void CallAction(CombatActionDataMB data);
    public abstract void UpdateAction(CombatActionDataMB data);
    public abstract Type GetTypeCombatActionDataMB();
}
