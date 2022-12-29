using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Clickable : MonoBehaviour
{
    public event Action OnClick;

    private BoxCollider2D _collider;
    private bool _isEnable;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;
    }

    public void Activate()
    {
        _collider.enabled = true;
        _isEnable = true;
    }

    public void Deactivate()
    {
        _collider.enabled = false;
        _isEnable = false;
    }

    private void OnMouseDown()
    {
        if (_isEnable == true)
            OnClick?.Invoke();
    }
}