using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _score;

    public void SetText(int value)
    {
        _score.text = $"{value}";
    }
}
