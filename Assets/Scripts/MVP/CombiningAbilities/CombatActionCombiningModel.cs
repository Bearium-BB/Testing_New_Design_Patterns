using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class CombatActionCombiningModel
{
    public CombatActionSpellElement elementOneCombatActionSpellElement;
    public CombatActionSpellElement elementTwoCombatActionSpellElement;


    public CombatActionSO elementOneElementTwoCombatAction;
    public CombatActionSO elementTwoElementOneCombatAction;
    public CombatActionSO elementTwoElementTwoCombatAction;
    public CombatActionSO elementOneElementOneCombatAction;


    public List<SpellElement> elements = new List<SpellElement> { SpellElement.none, SpellElement.none };
    public ObservableProperty<int> replaceIndex = new ObservableProperty<int>();


    public CombatActionCombiningModel(
        CombatActionSpellElement elementOneCombatActionSpellElement,
        CombatActionSpellElement elementTwoCombatActionSpellElement,
        CombatActionSO elementOneElementTwoCombatAction,
        CombatActionSO elementTwoElementOneCombatAction,
        CombatActionSO elementTwoElementTwoCombatAction,
        CombatActionSO elementOneElementOneCombatAction)
    {
        this.elementOneCombatActionSpellElement = elementOneCombatActionSpellElement;
        this.elementTwoCombatActionSpellElement = elementTwoCombatActionSpellElement;

        this.elementOneElementTwoCombatAction = elementOneElementTwoCombatAction;
        this.elementTwoElementOneCombatAction = elementTwoElementOneCombatAction;
        this.elementTwoElementTwoCombatAction = elementTwoElementTwoCombatAction;
        this.elementOneElementOneCombatAction = elementOneElementOneCombatAction;
        replaceIndex.Value = 0;
    }

    public void ReplaceElement(SpellElement spellElement)
    {
        elements[replaceIndex.Value] = spellElement;
        replaceIndex.Value++;
        if (replaceIndex.Value > elements.Count - 1)
        {
            replaceIndex.Value = 0;
        }
    }

    public CombatActionSO CombatActionOutcome()
    {
        SpellElement oneSpellElement = elements[0];
        SpellElement twoSpellElement = elements[1];

        if (oneSpellElement == SpellElement.elementOne && twoSpellElement == SpellElement.elementTwo)
        {
            return elementOneElementTwoCombatAction;
        }
        else if (oneSpellElement == SpellElement.elementTwo && twoSpellElement == SpellElement.elementOne)
        {
            return elementTwoElementOneCombatAction;
        }
        else if (oneSpellElement == SpellElement.elementTwo && twoSpellElement == SpellElement.elementTwo)
        {
            return elementTwoElementTwoCombatAction;
        }
        else if (oneSpellElement == SpellElement.elementOne && twoSpellElement == SpellElement.elementOne)
        {
            return elementOneElementOneCombatAction;
        }

        return null;
    }

    public SpellElement GetElementsIndex(int index)
    {
        return elements[index];
    }

}

public enum SpellElement
{
    none,
    elementOne,
    elementTwo
}

public enum SpellElementOutcome
{
    abilityOne,
    abilityTwo,
    abilityThree,
    abilityFour,
    unknown
}

