using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FruitAnimator : MonoBehaviour
{
    private Animator _selfAnimator;

    private const string TRIGGER_COLLECT = "Collect";
    private const string TRIGGER_CRUSH = "Crush";
    private const string TRIGGER_FADE = "Fade";

    private void Awake()
    {
        _selfAnimator = GetComponent<Animator>();
    }

    public void SetCollectState()
    {
        _selfAnimator.SetTrigger(TRIGGER_COLLECT);
    }

    public void SetCrushState()
    {
        _selfAnimator.SetTrigger(TRIGGER_CRUSH);
    }

    public void SetFadeState()
    {
        _selfAnimator.SetTrigger(TRIGGER_FADE);
    }
}