using System;
using UnityEngine;

public class Fruit : CollectingObject
{
    public event Action OnCrush;

    [SerializeField] private int _valueScore;

    private Score _playerScore;
    private Health _playerHealth;

    public void Init(Score playerScore, Health playerHealth)
    {
        _playerScore = playerScore;
        _playerHealth = playerHealth;

        this.Enable();
    }

    private protected override void Collecting()
    {
        _playerScore.Add(_valueScore);
        Destroy();
    }

    public void Crush()
    {
        _playerHealth.ReduceByOne();
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        _valueScore = Mathf.Clamp(_valueScore, 1, int.MaxValue);      
    }
}
