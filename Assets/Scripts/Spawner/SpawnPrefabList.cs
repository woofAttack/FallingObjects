using System.Linq;
using UnityEngine;

public class SpawnPrefabList
{
    private GameObject[] _prefabs;

    public SpawnPrefabList()
    {
        _prefabs = Resources.LoadAll<GameObject>("Prefabs");
    }

    public GameObject GetRandom()
    {
        var index = Random.Range(0, _prefabs.Length);
        return _prefabs[index];
    }
}
