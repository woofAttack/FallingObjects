public class BombPrefabHandler
{
    private Health _health;

    public BombPrefabHandler(Health health)
    {
        _health = health ?? throw new System.ArgumentNullException(nameof(health));
    }

    public Bomb Init(Bomb bomb)
    {
        bomb.Init(_health);
        return bomb;
    }
}