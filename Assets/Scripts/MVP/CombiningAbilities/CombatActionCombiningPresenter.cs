using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class CombatActionCombiningPresenter
{
    CombatActionCombiningModel combatActionCombiningModel;
    ICombatActionCombiningView combatActionCombiningModelView;

    public CombatActionCombiningPresenter(CombatActionCombiningModel combatActionCombiningModel, ICombatActionCombiningView combatActionCombiningModelView)
    {
        this.combatActionCombiningModel = combatActionCombiningModel;
        this.combatActionCombiningModelView = combatActionCombiningModelView;

        this.combatActionCombiningModelView.elementOneCombatActionSpellElement = combatActionCombiningModel.elementOneCombatActionSpellElement;

        this.combatActionCombiningModelView.elementTwoCombatActionSpellElement = combatActionCombiningModel.elementTwoCombatActionSpellElement;

        combatActionCombiningModelView.onInputElement += HandleCombining;

        combatActionCombiningModelView.onInputCombatActionSO += HandleCastingOfCombination;

    }

    public void HandleCombining(CombatActionSpellElement combatActionSpellElement)
    {
        combatActionCombiningModel.ReplaceElement(combatActionSpellElement.SpellElement);
        combatActionCombiningModelView.castCombatActionSpellElement(combatActionSpellElement);
    }

    public void HandleCastingOfCombination()
    {
        CombatActionSO combatActionSO = combatActionCombiningModel.CombatActionOutcome();

        combatActionCombiningModelView.castCombatActionSO(combatActionSO);
    }
}
