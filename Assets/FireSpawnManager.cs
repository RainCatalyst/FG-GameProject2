using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FireSpawnManager : MonoBehaviour
{

    private void Update()
    {
        if (_activePrefabs.Count < _spawnLocation.Count)
        {
            _timer += Time.deltaTime;
            if (_timer >= Random.Range(_minDelay, _maxDelay))
            {
                SpawnFirePrefab();
                _timer = 0f;
            }
        }
    }
        public void SpawnFirePrefab()
    {
        int randomIndex = Random.Range(0, _spawnLocation.Count);
        Transform spawnLocation = _spawnLocation[randomIndex];
        Instantiate(_prefabToSpawn, spawnLocation.position, spawnLocation.rotation);
        _activePrefabs.Add(_prefabToSpawn);
    }
    public void OnDestroyedPrefab(GameObject prefab)
    {
        _activePrefabs.Remove(prefab);
    }

    [SerializeField]
    private List<Transform> _spawnLocation;
    private List<GameObject> _activePrefabs = new List<GameObject>();

    [SerializeField]
    private GameObject _prefabToSpawn;


    [Header("Timer for fire prefab")]
    [SerializeField]
    private float _minDelay = 1f;
    [SerializeField]
    private float _maxDelay = 5f;
    private float _timer = 0f;
    
}
