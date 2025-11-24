using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActionCombiningViewModel
{
    public CombatActionCombiningModel model;


    public event Action<CombatActionSpellElement[]> elementUIUpdate;

    public event Action<CombatActionSO> combatActionSOUIUpdate;

    public CombatActionCombiningViewModel(CombatActionCombiningModel model)
    {
        this.model = model;
        model.replaceIndex.OnValueChanged += index => UpdateUIElement();
        model.replaceIndex.OnValueChanged += index => UpdateUICombatActionSO();

        //view.onInputCombatActionSO +=
    }

    private CombatActionSpellElement Convert(SpellElement element)
    {
        switch (element)
        {
            case SpellElement.elementOne:
                return model.elementOneCombatActionSpellElement;

            case SpellElement.elementTwo:
                return model.elementTwoCombatActionSpellElement;

            case SpellElement.none:
            default:
                return null;
        }
    }
    public CombatActionSpellElement[] UpdateUIElement()
    {
        CombatActionSpellElement[] arr = new CombatActionSpellElement[2];
        arr[0] = Convert(model.elements[0]);
        arr[1] = Convert(model.elements[1]);

        elementUIUpdate?.Invoke(arr);
        return arr;
    }

    public CombatActionSO UpdateUICombatActionSO()
    {
        CombatActionSO combatActionSO = model.CombatActionOutcome();

        combatActionSOUIUpdate?.Invoke(combatActionSO);

        return combatActionSO;
    }

}
