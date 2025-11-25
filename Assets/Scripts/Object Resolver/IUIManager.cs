using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager 
{
    string managerID { get; }
    void SetText(string elementID, string text);
    void Show(string elementID);
    void Hide(string elementID);
}
