public class Game
{
    private SpawnList _spawnList;
    private Timer _timer;

    public Game(SpawnList spawnList, Timer timer)
    {
        _spawnList = spawnList ?? throw new System.ArgumentNullException(nameof(spawnList));
        _timer = timer ?? throw new System.ArgumentNullException(nameof(timer));
    }

    public void Enable()
    {
        _timer.Enable();

        _timer.OnTimeLeft += SpawnGameElement;
    }

    public void Disable()
    {
        _timer.Disable();

        _timer.OnTimeLeft -= SpawnGameElement;
    }

    public void End()
    {
        _timer.Disable();
    }

    private void SpawnGameElement()
    {
        _spawnList.MakeRandom();
    }
}
