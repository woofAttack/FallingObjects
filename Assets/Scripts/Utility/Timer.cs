using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action OnTimeLeft;

    [SerializeField] private float _time = 1f;

    private float _currentTime;
    private IEnumerator _invokePerTime;

    private void Awake()
    {
        _currentTime = _time;

        _invokePerTime = TickPerTime();
    }

    public void Enable()
    {
        StartCoroutine(_invokePerTime);
    }

    public void Disable()
    {
        StopCoroutine(_invokePerTime);
    }

    private IEnumerator TickPerTime()
    {
        while (true)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0f)
            {
                OnTimeLeft?.Invoke();

                _currentTime = _time;
            }

            yield return null;
        }
    }

    private void OnValidate()
    {
        _time = Mathf.Clamp(_time, 0.5f, float.MaxValue);
    }
}