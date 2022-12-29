using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("Health Setting")]
    [SerializeField] private HealthView _healthView;
    [SerializeField] private int _startHealthCount;
    private HealthPresenter _healthPresenter;
    private Health _playerHealth;

    [Header("Score Setting")]
    [SerializeField] private ScoreView _scoreView;
    private const int START_SCORE_VALUE = 0;
    private ScorePresenter _scorePresenter;
    private Score _playerScore;

    [Header("Spawner Setting")]
    [SerializeField] private SpawnPrefabCollectingObjects _list;
    private FruitPrefabHandler _fruit;
    private BombPrefabHandler _bomb;

    [Header("Game Setting")]
    [SerializeField] private GameOverView _overView;
    [SerializeField] private Timer _timer;
    private GameOverPresenter _gameOverPresenter;
    private ScorePresenter _gameScorePresenter;
    private Game _game;

    private void Awake()
    {
        SetupHealth();
        SetupScore();
        SetupSpawner();

        SetupGame();
    }

    private void SetupHealth()
    {
        _playerHealth = new Health(_startHealthCount);

        _healthView.ThrowExceptionIfNull();
        _healthView.Init(_startHealthCount);
        _healthView.SetCurrentValue(_startHealthCount);

        _healthPresenter = new HealthPresenter(_playerHealth, _healthView);
    }

    private void SetupScore()
    {
        _playerScore = new Score();

        _scoreView.ThrowExceptionIfNull();
        _scoreView.SetScoreText(START_SCORE_VALUE);

        _scorePresenter = new ScorePresenter(_playerScore, _scoreView);
    }
    
    private void SetupSpawner()
    {
        _list.ThrowExceptionIfNull();

        _fruit = new FruitPrefabHandler(_playerHealth, _playerScore);
        _bomb = new BombPrefabHandler(_playerHealth);

        _list.Init(_fruit, _bomb);
    }
    
    private void SetupGame()
    {
        _timer.ThrowExceptionIfNull();

        _overView.ThrowExceptionIfNull();
        _overView.SetScoreText(START_SCORE_VALUE);

        _gameScorePresenter = new ScorePresenter(_playerScore, _overView);

        _game = new Game(_list, _timer, _playerHealth);

        _gameOverPresenter = new GameOverPresenter(_game, _overView);
    }

    private void OnEnable()
    {
        _healthPresenter.Enable();
        _scorePresenter.Enable();
        _gameScorePresenter.Enable();
        _gameOverPresenter.Enable();
        _game.Enable();
    }

    private void OnDisable()
    {
        _healthPresenter.Disable();
        _scorePresenter.Disable();
        _gameScorePresenter.Disable();
        _gameOverPresenter.Disable();
        _game.Disable();
    }

    private void OnValidate()
    {
        _startHealthCount = Mathf.Clamp(_startHealthCount, 1, int.MaxValue);
    }
}