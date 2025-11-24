using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableProperty<T>
{
    private T _value;
    public T Value
    {
        get => _value;
        set
        {
            if (Equals(_value, value)) return;
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }

    public event System.Action<T> OnValueChanged;
}