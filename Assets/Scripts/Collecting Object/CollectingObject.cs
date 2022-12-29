using System;
using UnityEngine;

[RequireComponent(typeof(MovementFalling))]
[RequireComponent(typeof(Clickable))]
public abstract class CollectingObject : MonoBehaviour, IDestructible
{
    public event Action OnCollect;
    public event Action<IDestructible> OnDestroyObject;

    [SerializeField] private MovementFalling _movening;
    private Clickable _clickableComponent;

    #region Unity Engine 
    private void Awake()
    {
        _clickableComponent = GetComponent<Clickable>();
        _movening = GetComponent<MovementFalling>();

        _clickableComponent.ThrowExceptionIfNull();
        _movening.ThrowExceptionIfNull();

        ChildAwake();

        this.Disable();
    }

    private void OnEnable()
    {
        _clickableComponent.OnClick += Collect;
        ChildOnEnable();
    }

    private void OnDisable()
    {
        _clickableComponent.OnClick -= Collect;
        ChildOnDisable();
    }

    private protected virtual void ChildAwake() { }
    private protected virtual void ChildOnEnable() { }
    private protected virtual void ChildOnDisable() { }

    #endregion

    public void Activate()
    {
        _movening.Activate();
        _clickableComponent.Activate();
    }
    public void Deactivate()
    {
        _movening.Deactivate();
        _clickableComponent.Deactivate();
    }

    public void Fade()
    {
        Deactivate();
        OnFade();
    }
    private protected virtual void OnFade() { }


    public void Collect()
    {
        Collecting();
        OnCollect?.Invoke();
    }
    private protected abstract void Collecting();

    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        OnDestroyObject.Invoke(this);
    }
}