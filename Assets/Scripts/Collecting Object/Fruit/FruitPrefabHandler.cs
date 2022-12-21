public class FruitPrefabHandler
{
    private Health _health;
    private Score _score;

    public FruitPrefabHandler(Health health, Score score)
    {
        _health = health ?? throw new System.ArgumentNullException(nameof(health));
        _score = score ?? throw new System.ArgumentNullException(nameof(score));
    }

    public Fruit Init(Fruit fruit)
    {
        fruit.Init(_score, _health);
        return fruit;
    }
}