using UnityEngine;

[System.Serializable]
public class SpawnerFruit : ISpawner
{
    [SerializeField] private Fruit _prefab;
    [SerializeField] private int _scoreForClickedFruit;

    private FruitMechanic.Builder _mechanic;

    public void Spawn(SpawnZone zone)
    {
        var spawnedFruit = zone.InstantiatePrefab(_prefab);
        _mechanic.Setup(spawnedFruit, _scoreForClickedFruit).Enable();

        spawnedFruit.EnableMovening();
    }

    [System.Serializable]
    public class Builder
    {
        [SerializeField] private SpawnerFruit _spawner;

        public SpawnerFruit Setup(FruitMechanic.Builder builder)
        {
            _spawner._mechanic = builder;
            return _spawner;
        }
    }
}
