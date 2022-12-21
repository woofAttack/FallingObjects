using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour, IScoreView
{
    [SerializeField] private Text _score;

    private void Awake()
    {
        _score.ThrowExceptionIfNull();
    }

    public void SetScoreText(int value)
    {
        _score.text = $"{value}";
    }
}
