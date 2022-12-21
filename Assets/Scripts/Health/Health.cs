using System;

public class Health
{
    public Action<int> OnChange;
    public Action OnOver;

    private int _count;

    public Health(int count)
    {
        if (count <= 0)
            throw new Exception($"Init count for Health not equal or below zero. (was tryed set {count}");

        _count = count;
    }

    public void ReduceByOne()
    {
        if (_count == 0)
            throw new Exception("Health already equal zero.");

        _count -= 1;
        OnChange?.Invoke(_count);

        if (_count == 0)
            OnOver?.Invoke();
    }
}