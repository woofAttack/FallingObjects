using System;

public class Score
{
    public Action<int> OnChange;

    private int _value = 0;

    public void Add(int value)
    {
        if (value < 0)
            throw new Exception("Value for add score can't equal below zero.");

        _value += value;
        OnChange?.Invoke(_value);
    }
}
