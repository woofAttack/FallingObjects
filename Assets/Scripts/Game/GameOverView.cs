using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour, IScoreView
{
    [SerializeField] private Text _score;
    [SerializeField] private Button _button;

    private void Awake()
    {
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

    public void Show()
    {
        this.Enable();
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
