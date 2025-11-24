using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class HoldSpellElement : MonoBehaviour
{
    public int replaceIndex = 0;

    private List<SpellElement> elements = new List<SpellElement> { SpellElement.none, SpellElement.none };

    public void replaceElement(SpellElement spellElement)
    {
        elements[replaceIndex] = spellElement; 
        replaceIndex++;
        if (replaceIndex > elements.Count - 1)
        {
            replaceIndex = 0;
        }
        //Debug.Log($"{elements[0]} + {elements[1]} = {whatSpellElementOutcome(elements[0], elements[1])}");
    }


    public SpellElementOutcome whatSpellElementOutcome()
    {
        //SpellElement oneSpellElement = elements[0];
        //SpellElement twoSpellElement = elements[1];

        //if (oneSpellElement == SpellElement.elementOne && twoSpellElement == SpellElement.elementTwo)
        //{
        //    return SpellElementOutcome.steamCloud;
        //}
        //else if (oneSpellElement == SpellElement.elementTwo && twoSpellElement == SpellElement.elementOne)
        //{
        //    return SpellElementOutcome.frostBurst;
        //}
        //else if (oneSpellElement == SpellElement.elementTwo && twoSpellElement == SpellElement.elementTwo)
        //{
        //    return SpellElementOutcome.flameTorrent;
        //}
        //else if (oneSpellElement == SpellElement.elementOne && twoSpellElement == SpellElement.elementOne)
        //{
        //    return SpellElementOutcome.LightningBolt;
        //}

        return SpellElementOutcome.unknown;
    }

    public SpellElement GetElementsIndex(int index)
    {
        return elements[index];
    }

}

//public enum SpellElement
//{
//    none,
//    water,
//    fire
//}

//public enum SpellElementOutcome
//{
//    steamCloud,
//    frostBurst,
//    flameTorrent,
//    LightningBolt,
//    unknown
//}

//Water + Fire = Steam Cloud
//Fire + Water = Frost Burst
//Fire + Fire = Flame Torrent
//Water + Water = Water Surge

