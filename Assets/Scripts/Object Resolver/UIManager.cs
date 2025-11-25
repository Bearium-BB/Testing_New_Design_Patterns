using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    public string ID;
    public string managerID => ID;

    [System.Serializable]
    public struct UITextEntry
    {
        public string ID;
        public TextMeshProUGUI TextComponent;
    }

    [SerializeField] private List<UITextEntry> textBoxes;

    private Dictionary<string, TextMeshProUGUI> textMap;

    private void Awake()
    {
        textMap = new Dictionary<string, TextMeshProUGUI>();
        foreach (var entry in textBoxes)
        {
            if (entry.TextComponent != null && !string.IsNullOrEmpty(entry.ID))
                textMap[entry.ID] = entry.TextComponent;
        }
    }

    public void SetText(string elementID, string text)
    {
        if (textMap.TryGetValue(elementID, out var txt))
            txt.text = text;
    }

    public void Show(string elementID)
    {
        if (textMap.TryGetValue(elementID, out var txt))
            txt.gameObject.SetActive(true);
    }

    public void Hide(string elementID)
    {
        if (textMap.TryGetValue(elementID, out var txt))
            txt.gameObject.SetActive(false);
    }
}
