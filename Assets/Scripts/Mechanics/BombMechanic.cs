using System;

public class BombMechanic 
{
    private Health _health;
    private Bomb _bomb;

    public BombMechanic(Health health, Bomb bomb)
    {
        _health = health;
        _bomb = bomb;
    }

    public void Enable()
    {
        _health.OnOver += _bomb.DisableMovening;
        _bomb.OnCollect += _health.ReduceByOne;
    }

    public void Disable()
    {
        _health.OnOver -= _bomb.DisableMovening;
        _bomb.OnCollect -= _health.ReduceByOne;
    }

    public class Builder
    {
        private Health _health;

        public Builder(Health health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public BombMechanic Setup(Bomb bomb)
        {
            if (bomb is null)
                throw new ArgumentNullException(nameof(bomb));

            return new BombMechanic(_health, bomb);
        }
    }
}