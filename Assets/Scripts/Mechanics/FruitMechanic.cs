using System;

public class FruitMechanic
{
    private Health _health;
    private Score _score;

    private Fruit _fruit;
    private int _valueScore;

    private FruitMechanic(Health health, Score score, Fruit fruit, int valueScore)
    {
        _health = health;
        _score = score;
        _fruit = fruit;
        _valueScore = valueScore;
    }

    public void Enable()
    {
        _health.OnOver += _fruit.DisableMovening;
        _fruit.OnCollect += AddScore;
        _fruit.OnCrush += _health.ReduceByOne;
    }

    public void Disable()
    {
        _health.OnOver -= _fruit.DisableMovening;
        _fruit.OnCollect -= AddScore;
        _fruit.OnCrush -= _health.ReduceByOne;
    }

    private void AddScore() => _score.Add(_valueScore);

    public class Builder
    {
        private Health _health;
        private Score _score;

        public Builder(Health health, Score score)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public FruitMechanic Setup(Fruit fruit, int valueScore)
        {
            if (fruit is null)           
                throw new ArgumentNullException(nameof(fruit));           

            if (valueScore < 0)
                throw new ArgumentNullException(nameof(valueScore));

            return new FruitMechanic(_health, _score, fruit, valueScore);
        }
    }
}
