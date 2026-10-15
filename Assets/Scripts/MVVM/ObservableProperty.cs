
//A generic observable property that notifies listeners whenever its value changes.
//Useful for UI binding, reactive systems, or decoupled event-driven logic.
public class ObservableProperty<T>
{
    // Internal backing field that stores the actual value.
    private T _value;

    //Gets or sets the value of the property.
    //When the value changes, the OnValueChanged event is triggered.
    public T Value
    {
        // Returns the current stored value.
        get => _value;

        // Sets the value and notifies listeners if the value has changed.
        set
        {
            // Prevents unnecessary updates if the new value is equal to the current value.
            if (Equals(_value, value)) return;

            // Update the stored value.
            _value = value;

            // Notify all subscribers that the value has changed.
            OnValueChanged?.Invoke(_value);
        }
    }

    //Event triggered whenever the Value changes.
    //Subscribers receive the new value as a parameter.
    public event System.Action<T> OnValueChanged;
}