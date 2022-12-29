using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour, IScoreView
{
    [SerializeField] private Text _score;
    [SerializeField] private Button _button;

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Background _background;

    private void Awake()
    {
        _scoreView.ThrowExceptionIfNull();
        _background.ThrowExceptionIfNull();
        _score.ThrowExceptionIfNull();
        _button.ThrowExceptionIfNull();

        this.Disable();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ReloadGame);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ReloadGame);
    }

    public void SetScoreText(int value)
    {
        _score.text = $"{value} points!";
    }

    public void HideOtherUI()
    {
        _scoreView.Disable();
    }

    public void Show()
    {
        _background.SetStateFade();
        this.Enable();
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
