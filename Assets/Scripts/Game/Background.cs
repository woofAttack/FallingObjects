using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Background : MonoBehaviour
{
    private Animator _animator;
    private const string TRIGGER_FADE = "Fade";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetStateFade()
    {
        _animator.SetTrigger(TRIGGER_FADE);
    }
}
