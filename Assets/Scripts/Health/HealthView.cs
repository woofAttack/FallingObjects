using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Text _health;

    [SerializeField] private HeartView _heartPrefab;
    private List<HeartView> _hearts = new List<HeartView>();

    public void Init(int valueHeart)
    {
        for (int i = 0; i < valueHeart; i++)
        {
            var heart = Instantiate(_heartPrefab, transform);
            _hearts.Add(heart);
        }
    }

    public void BrakeHeartByOne()
    {
        var heartForBrake = _hearts.Last();
        heartForBrake.SetStateBrake();

        _hearts.Remove(heartForBrake);
    }

    public void SetCurrentValue(int value)
    {
        _health.text = $"{value}";
    }
}
