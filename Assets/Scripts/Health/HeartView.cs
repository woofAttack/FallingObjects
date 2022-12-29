using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeartView : MonoBehaviour
{
    private Animator _animator;
    private const string STATE_BRAKE = "Brake";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetStateBrake()
    {
        _animator.SetTrigger(STATE_BRAKE);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}