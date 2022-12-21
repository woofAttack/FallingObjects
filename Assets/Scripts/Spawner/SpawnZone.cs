using UnityEngine;

[RequireComponent(typeof(GizmosWireCube))]
public class SpawnZone : MonoBehaviour
{
    private Transform _selfTransform;
    private Vector3 _selfPosition;

    private Vector2 _rangeX;

    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
        _selfPosition = _selfTransform.position;

        var halfScaleX = _selfTransform.localScale.x * 0.5f;
        _rangeX = new Vector2(-1 * halfScaleX, halfScaleX);
    }

    public T InstantiatePrefab<T>(T gameObject) where T: Object
    {
        var randomPositionX = Random.Range(_rangeX.x, _rangeX.y);
        var spawnPosition = _selfPosition.WithValueX(randomPositionX);

        return Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }
}
