using System;
using UnityEngine;

[RequireComponent(typeof(MovementFalling))]
public abstract class CollectingObject : MonoBehaviour, IDestructible
{
    public event Action OnCollect;
    public event Action<IDestructible> OnDestroyObject;

    [SerializeField] private MovementFalling _movening;

    #region Unity Engine 
    private void Awake()
    {
        _movening.ThrowExceptionIfNull();
        ChildAwake();

        this.Disable();
    }

    private void OnEnable()
    {
        ChildOnEnable();
    }

    private void OnDisable()
    {
        ChildOnDisable();
    }

    private protected virtual void ChildAwake() { }
    private protected virtual void ChildOnEnable() { }
    private protected virtual void ChildOnDisable() { }

    #endregion

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

    private void OnDestroy()
    {
        OnDestroyObject.Invoke(this);
    }
}
