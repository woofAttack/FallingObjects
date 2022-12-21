using System.Collections.Generic;
using UnityEngine;

public class SpawnList : MonoBehaviour
{
    [SerializeField] private SpawnerFruit.Builder _fruitSimple;
    [SerializeField] private SpawnerFruit.Builder _fruitDouble;
    [SerializeField] private SpawnerBomb.Builder _bomb;

    [SerializeField] private SpawnZone _zone;

    private List<ISpawner> _spawners = new List<ISpawner>();

    private void Awake()
    {
        _zone.ThrowExceptionIfNull();
    }

    public void Init(FruitMechanic.Builder builder1, BombMechanic.Builder builder2)
    {
        _spawners.Add(_fruitSimple.Setup(builder1));
        _spawners.Add(_fruitDouble.Setup(builder1));
        _spawners.Add(_bomb.Setup(builder2));
    }

    public void MakeRandom()
    {
        var index = UnityEngine.Random.Range(0, _spawners.Count);
        _spawners[index].Spawn(_zone);
    }
}
