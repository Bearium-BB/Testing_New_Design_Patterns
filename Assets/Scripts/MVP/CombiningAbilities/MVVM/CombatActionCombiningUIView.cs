using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatActionCombiningUIView : MonoBehaviour
{
    [Inject] private IUIService service;


    public void Bind(CombatActionCombiningViewModel vm)
    {
        vm.elementUIUpdate += UpdateElementUI;
        vm.combatActionSOUIUpdate += UpdateCombatActionSO;

        UpdateElementUI(vm.UpdateUIElement());

        UpdateCombatActionSO(vm.UpdateUICombatActionSO());
    }




    public void UpdateElementUI(CombatActionSpellElement[] arr)
    {
        if (arr[0] != null)
        {
            service.SetText("CASO_COMB", "E1", arr[0].name);
        }
        else
        {
            service.SetText("CASO_COMB", "E1", "no element");

        }

        if (arr[1] != null)
        {
            service.SetText("CASO_COMB", "E2", arr[1].name);
        }
        else
        {
            service.SetText("CASO_COMB", "E2", "no element");
        }
    }

    public void UpdateCombatActionSO(CombatActionSO combatActionSO)
    {
        if (combatActionSO != null)
        {
            if (combatActionSO is CombatActionTimerSO caso)
            {
                service.SetText("CASO_COMB", "COMB", caso.name);

            }
        }
        else
        {
            service.SetText("CASO_COMB", "COMB", "no combatActionSO");

        }
    }
}
