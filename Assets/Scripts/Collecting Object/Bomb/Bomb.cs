using System;

public class Bomb : CollectingObject
{
    private Health _playerHealth;

    private protected override void Collecting()
    {
        _playerHealth.ReduceByOne();

        Destroy(gameObject);
    }

    public void Init(Health health)
    {
        _playerHealth = health ?? throw new ArgumentNullException(nameof(health));

        this.Enable();
    }
}
