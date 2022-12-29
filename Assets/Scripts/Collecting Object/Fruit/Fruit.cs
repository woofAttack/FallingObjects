using System;
using UnityEngine;

[RequireComponent(typeof(FruitAnimator))]
public class Fruit : CollectingObject
{
    [SerializeField] private int _valueScore;

    private FruitAnimator _animator;

    private Score _playerScore;
    private Health _playerHealth;

    private protected override void ChildAwake()
    {
        _animator = GetComponent<FruitAnimator>();
    }

    public void Init(Score playerScore, Health playerHealth)
    {
        _playerScore = playerScore;
        _playerHealth = playerHealth;

        this.Enable();
    }

    private protected override void Collecting()
    {
        _playerScore.Add(_valueScore);

        Deactivate();
        _animator.SetCollectState();
    }

    public void Crush()
    {
        _playerHealth.ReduceByOne();

        Deactivate();
        _animator.SetCrushState();      
    }

    private protected override void OnFade()
    {
        _animator.SetFadeState();
    }

    private void OnValidate()
    {
        _valueScore = Mathf.Clamp(_valueScore, 1, int.MaxValue);      
    }
}
