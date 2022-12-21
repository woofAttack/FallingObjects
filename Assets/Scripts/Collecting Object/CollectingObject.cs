using System;
using UnityEngine;

[RequireComponent(typeof(MovementFalling))]
public abstract class CollectingObject : MonoBehaviour
{
    public event Action OnCollect;

    [SerializeField] private MovementFalling _movening;

    private void Awake()
    {
        Debug.Log("Awake");

        _movening.ThrowExceptionIfNull();
        ChildAwake();
    }
    private protected virtual void ChildAwake() { }

    private void OnEnable()
    {
        Debug.Log("Enable");
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    public void EnableMovening()
    {
        _movening.Enable();
    }

    public void DisableMovening()
    {
        _movening.Disable();
    }

    private void OnMouseDown()
    {
        Collect();
    }

    public void Collect()
    {
        Collecting();
        OnCollect?.Invoke();
    }

    private protected abstract void Collecting();
}
