using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatActionCombiningUIView : MonoBehaviour
{
    public TextMeshProUGUI textBoxE1;
    public TextMeshProUGUI textBoxE2;
    public TextMeshProUGUI textBoxCASO;

    public void Bind(CombatActionCombiningViewModel vm)
    {
        vm.elementUIUpdate += UpdateElementUI;
        UpdateElementUI(vm.UpdateUIElement());

        vm.combatActionSOUIUpdate += UpdateCombatActionSO;
        UpdateCombatActionSO(vm.UpdateUICombatActionSO());
    }


    public void UpdateElementUI(CombatActionSpellElement[] arr)
    {

        if (arr[0] != null)
        {
            textBoxE1.text = arr[0].name;
        }
        else
        {
            textBoxE1.text = "no element";
        }

        if (arr[1] != null)
        {
            textBoxE2.text = arr[1].name;
        }
        else
        {
            textBoxE2.text = "no element";
        }
    }

    public void UpdateCombatActionSO(CombatActionSO combatActionSO)
    {
        if (combatActionSO != null)
        {
            if (combatActionSO is CombatActionTimerSO caso)
            {
                textBoxCASO.text = caso.name;
            }
        }
        else
        {
            textBoxCASO.text = "no combatActionSO";
        }
    }
}
