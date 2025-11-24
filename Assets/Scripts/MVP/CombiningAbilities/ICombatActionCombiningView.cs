using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatActionCombiningView
{
    public CombatActionSpellElement elementOneCombatActionSpellElement { get; set; }

    public CombatActionSpellElement elementTwoCombatActionSpellElement { get; set; }

    public event Action<CombatActionSpellElement> onInputElement;

    public event Action onInputCombatActionSO;

    public void castCombatActionSpellElement(CombatActionSpellElement combatActionSpellElement);

    public void castCombatActionSO(CombatActionSO combatActionSO);
}
