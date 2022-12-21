using UnityEngine;

public class Spawner
{
    private SpawnZone _zone;
    private SpawnPrefabList _list;

    public Spawner(SpawnZone zone, SpawnPrefabList list)
    {
        _zone = zone ?? throw new System.ArgumentNullException(nameof(zone));
        _list = list ?? throw new System.ArgumentNullException(nameof(list));
    }

    public GameObject Execute()
    {
        var prefabForSpawn = _list.GetRandom();
        return _zone.InstantiatePrefab(prefabForSpawn);
    }
}