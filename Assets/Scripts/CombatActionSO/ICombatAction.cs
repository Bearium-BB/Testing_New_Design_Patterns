using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatAction
{
    void CallAction(CombatActionDataMB data);

    void UpdateAction(CombatActionDataMB data);

    public Type GetTypeCombatActionDataMB();
}
