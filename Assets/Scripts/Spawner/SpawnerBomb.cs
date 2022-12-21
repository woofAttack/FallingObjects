using UnityEngine;

[System.Serializable]
public class SpawnerBomb : ISpawner
{
    [SerializeField] private Bomb _prefab;

    private BombMechanic.Builder _mechanic;

    public void Spawn(SpawnZone zone)
    {
        var spawnedBomb = zone.InstantiatePrefab(_prefab);
        _mechanic.Setup(spawnedBomb).Enable();
        

        spawnedBomb.EnableMovening();
    }

    [System.Serializable]
    public class Builder
    {
        [SerializeField] private SpawnerBomb _spawner;

        public SpawnerBomb Setup(BombMechanic.Builder builder)
        {
            _spawner._mechanic = builder;
            return _spawner;
        }
    }
}
