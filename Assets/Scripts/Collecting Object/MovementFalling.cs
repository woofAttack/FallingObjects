using UnityEngine;

public class MovementFalling : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _selfTransform;
    private bool _canMove = false;

    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (_canMove == false) return;

        _selfTransform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    public void Activate() => _canMove = true;
    public void Deactivate() => _canMove = false;
}