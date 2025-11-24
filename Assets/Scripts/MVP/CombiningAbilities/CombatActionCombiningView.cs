using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActionCombiningView : MonoBehaviour, ICombatActionCombiningView
{
    public CombatActionSpellElement elementOneCombatActionSpellElement { get; set; }

    public CombatActionSpellElement elementTwoCombatActionSpellElement { get; set; }

    public event Action<CombatActionSpellElement> onInputElement;

    public event Action onInputCombatActionSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onInputCombatActionSO?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            onInputElement?.Invoke(elementOneCombatActionSpellElement);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            onInputElement?.Invoke(elementTwoCombatActionSpellElement);
        }
    }


    public void castCombatActionSpellElement(CombatActionSpellElement combatActionSpellElement)
    {
        Debug.Log(combatActionSpellElement.name);
    }

    public void castCombatActionSO(CombatActionSO combatActionSO)
    {
        if(combatActionSO != null)
        {
            Debug.Log(combatActionSO.name);

        }
    }
}
