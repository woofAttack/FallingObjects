using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabCollectingObjects : MonoBehaviour
{
    [SerializeField] private Fruit _simple;
    [SerializeField] private Fruit _double;
    [SerializeField] private Bomb _bomb;

    [SerializeField] private SpawnZone _zone;

    private List<Func<CollectingObject>> _spawnAction = new List<Func<CollectingObject>>();

    private void Awake()
    {
        _simple.ThrowExceptionIfNull();
        _double.ThrowExceptionIfNull();
        _bomb.ThrowExceptionIfNull();

        _zone.ThrowExceptionIfNull();
    }

    public void Init(FruitPrefabHandler forFruit, BombPrefabHandler forBomb)
    {
        if (forFruit is null)        
            throw new ArgumentNullException(nameof(forFruit));
        
        if (forBomb is null)      
            throw new ArgumentNullException(nameof(forBomb));
        
        _spawnAction.Add(() => forFruit.Init(_zone.InstantiatePrefab(_simple)));
        _spawnAction.Add(() => forFruit.Init(_zone.InstantiatePrefab(_double)));
        _spawnAction.Add(() => forBomb.Init(_zone.InstantiatePrefab(_bomb)));
    }

    public CollectingObject MakeRandom()
    {
        var index = UnityEngine.Random.Range(0, _spawnAction.Count);
        return _spawnAction[index].Invoke();
    }
}
