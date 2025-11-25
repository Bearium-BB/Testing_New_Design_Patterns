using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Injectable(typeof(IUIService), Lifetime.SceneScoped)]
public class UIService : MonoBehaviour , IUIService
{
    [SerializeField] private List<MonoBehaviour> uiManagers;

    private Dictionary<string, IUIManager> managerMap;

    private void Awake()
    {
        managerMap = new Dictionary<string, IUIManager>();
        foreach (var mb in uiManagers)
        {
            if (mb is IUIManager manager)
            {
                managerMap[manager.managerID] = manager;
            }
        }
    }

    public void SetText(string managerID, string elementID, string text)
    {
        if (managerMap.TryGetValue(managerID, out var manager))
            manager.SetText(elementID, text);
    }

    public void Show(string managerID, string elementID)
    {
        if (managerMap.TryGetValue(managerID, out var manager))
            manager.Show(elementID);
    }

    public void Hide(string managerID, string elementID)
    {
        if (managerMap.TryGetValue(managerID, out var manager))
            manager.Hide(elementID);
    }
}

[Serializable]
public struct UITextEntry
{
    public string ID; 
    public TextMeshProUGUI TextComponent; 
}
