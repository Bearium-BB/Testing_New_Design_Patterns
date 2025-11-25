using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell Element", menuName = "Combat Action/SpellElement", order = 1)]
public class CombatActionSpellElement : CombatActionTimerSO
{
    public SpellElement SpellElement;
    public override void CallAction(CombatActionDataMB data)
    {

    }

    public override void UpdateAction(CombatActionDataMB data)
    {

    }

    public override Type GetTypeCombatActionDataMB()
    {
        return typeof(CombatActionDataHoldSpellElement);
    }
}
