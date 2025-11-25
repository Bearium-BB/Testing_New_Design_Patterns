using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIService
{
    void SetText(string managerID, string elementID, string text);
    void Show(string managerID, string elementID);
    void Hide(string managerID, string elementID);
}
