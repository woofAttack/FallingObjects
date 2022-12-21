using System;
using UnityEngine;

public class Fruit : CollectingObject
{
    public event Action OnCrush;

    private protected override void Collecting()
    {
        Destroy(gameObject);
    }

    public void Crush()
    {
        OnCrush?.Invoke();
    }

    private void OnValidate()
    {
        //_valueScore = Mathf.Clamp(_valueScore, 1, int.MaxValue);      
    }
}
