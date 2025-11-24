using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CombatActionDataCollector : MonoBehaviour
{
    public List<CombatActionDataMB> combatActionDataMBs;

    public CombatActionDataMB GetData(CombatActionSO combatActionSO)
    {
        for (int i = 0; i < combatActionDataMBs.Count; i++) 
        {
            if (combatActionSO.GetTypeCombatActionDataMB() == combatActionDataMBs[i].GetType())
            {
                return combatActionDataMBs[i];
            }
        }

        return null;
    }

}


//[System.Serializable]
//public class MyDictionaryEntry
//{
//    public CombatActionSO combatActionSO;
//    public CombatActionDataMB combatActionDataMB;
//}

