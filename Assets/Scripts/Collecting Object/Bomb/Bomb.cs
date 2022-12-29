using System;
using UnityEngine;

[RequireComponent(typeof(FruitAnimator))]
public class Bomb : CollectingObject
{
    private Health _playerHealth;
    private FruitAnimator _animator;

    private protected override void ChildAwake()
    {
        _animator = GetComponent<FruitAnimator>();
    }

    private protected override void Collecting()
    {
        Deactivate();

        _playerHealth.ReduceByOne();
        _animator.SetCollectState();
    }

    private protected override void OnFade()
    {
        _animator.SetFadeState();
    }

    public void Init(Health health)
    {
        _playerHealth = health ?? throw new ArgumentNullException(nameof(health));

        this.Enable();
    }
}
