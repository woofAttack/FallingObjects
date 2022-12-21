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
    [SerializeField] private SpawnZone _zone;
    [SerializeField] private SpawnList _list;
    private FruitMechanic.Builder _builderFruit;
    private BombMechanic.Builder _builderBomb;

    //private SpawnPrefabList _listPrefab;
    //private Spawner _spawner;

    [Header("Game Setting")]


    [SerializeField] private Timer _timer;
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
        _healthView.SetText(_startHealthCount);

        _healthPresenter = new HealthPresenter(_playerHealth, _healthView);
    }

    private void SetupScore()
    {
        _playerScore = new Score();

        _scoreView.ThrowExceptionIfNull();
        _scoreView.SetText(START_SCORE_VALUE);

        _scorePresenter = new ScorePresenter(_playerScore, _scoreView);
    }
    
    private void SetupSpawner()
    {
        _zone.ThrowExceptionIfNull();
        _list.ThrowExceptionIfNull();

        _builderFruit = new FruitMechanic.Builder(_playerHealth, _playerScore);
        _builderBomb = new BombMechanic.Builder(_playerHealth);

        _list.Init(_builderFruit, _builderBomb);
    }
    
    private void SetupGame()
    {
        _timer.ThrowExceptionIfNull();

        _game = new Game(_list, _timer);
    }

    private void OnEnable()
    {
        _healthPresenter.Enable();
        _scorePresenter.Enable();
        _game.Enable();

        _playerHealth.OnOver += _game.End;
    }

    private void OnDisable()
    {
        _healthPresenter.Disable();
        _scorePresenter.Disable();
        _game.Disable();

        _playerHealth.OnOver -= _game.End;
    }

    private void OnValidate()
    {
        _startHealthCount = Mathf.Clamp(_startHealthCount, 1, int.MaxValue);
    }
}