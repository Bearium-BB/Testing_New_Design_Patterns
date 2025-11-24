using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActionCombiningInstaller : MonoBehaviour
{
    public CombatActionSpellElement elementOneCombatActionSpellElement;
    public CombatActionSpellElement elementTwoCombatActionSpellElement;


    public CombatActionSO elementOneElementTwoCombatAction;
    public CombatActionSO elementTwoElementOneCombatAction;
    public CombatActionSO elementTwoElementTwoCombatAction;
    public CombatActionSO elementOneElementOneCombatAction;

    public CombatActionCombiningView modelView;
    public CombatActionCombiningUIView combatActionCombiningUIView;


    private void Awake()
    {
        CombatActionCombiningModel modelCom = new CombatActionCombiningModel(
            elementOneCombatActionSpellElement, 
            elementTwoCombatActionSpellElement, 
            elementOneElementTwoCombatAction, 
            elementTwoElementOneCombatAction, 
            elementTwoElementTwoCombatAction, 
            elementOneElementOneCombatAction);

        CombatActionCombiningPresenter combatActionCombiningPresenter = new CombatActionCombiningPresenter(modelCom, modelView);

        CombatActionCombiningViewModel combatActionCombiningViewModel = new CombatActionCombiningViewModel(modelCom);
        combatActionCombiningUIView.Bind(combatActionCombiningViewModel);
    }
}
