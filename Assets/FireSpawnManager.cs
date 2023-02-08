using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FireSpawnManager : MonoBehaviour
{
    public List<Transform> SpawnLocation;
    public void Start()
    {
        SpawnFirePrefab();
    }
    public void SpawnFirePrefab()
    {
        int randomIndex = Random.Range(0, SpawnLocation.Count);
        Transform spawnLocation = SpawnLocation[randomIndex];
        Instantiate(_prefabToSpawn, spawnLocation.position, spawnLocation.rotation);
    }

    [SerializeField]
    private GameObject _prefabToSpawn;
}