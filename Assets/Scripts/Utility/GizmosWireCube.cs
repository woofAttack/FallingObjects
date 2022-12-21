using UnityEngine;

public class GizmosWireCube : MonoBehaviour
{
    [SerializeField] private Color _color = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
