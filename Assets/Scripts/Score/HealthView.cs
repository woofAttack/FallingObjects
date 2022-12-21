using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Text _health;

    public void SetText(int value)
    {
        _health.text = $"{value}";
    }
}