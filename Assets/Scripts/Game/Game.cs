using System;

public class Game
{
    public Action OnEnd;

    private SpawnPrefabCollectingObjects _spawnList;
    private Health _health;
    private Timer _timer;

    private OperationContainer<CollectingObject> _container;

    public Game(SpawnPrefabCollectingObjects spawnList, Timer timer, Health health)
    {
        _spawnList = spawnList ?? throw new System.ArgumentNullException(nameof(spawnList));
        _timer = timer ?? throw new System.ArgumentNullException(nameof(timer));
        _health = health ?? throw new System.ArgumentNullException(nameof(health));

        _container = new OperationContainer<CollectingObject>((x) => x.Fade());
    }

    public void Enable()
    {
        _timer.Enable();

        _timer.OnTimeLeft += SpawnGameElement;
        _health.OnOver += End;
    }

    public void Disable()
    {
        _timer.Disable();

        _timer.OnTimeLeft -= SpawnGameElement;
        _health.OnOver -= End;
    }

    public void End()
    {
        _timer.Disable();
        _container.InvokeOperation();

        OnEnd?.Invoke();
    }

    private void SpawnGameElement()
    {
        var spawnedObject = _spawnList.MakeRandom();
        _container.AddNew(spawnedObject);

        spawnedObject.Activate();
    }
}