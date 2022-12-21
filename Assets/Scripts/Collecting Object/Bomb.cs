using System;

public class Bomb : CollectingObject
{
    private protected override void Collecting()
    {
        Destroy(gameObject);
    }
}
