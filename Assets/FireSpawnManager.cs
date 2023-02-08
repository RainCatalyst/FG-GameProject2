using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FireSpawnManager : MonoBehaviour
{

    private void Update()
    {
        print($"active prefabs: {_activePrefabs.Count}");
        if (_activePrefabs.Count < _spawnLocation.Count)
        {
            _timer += Time.deltaTime;
            if (_timer >= _randomTimer)
            {
                SpawnFirePrefab();
                _randomTimer = Random.Range(_minDelay, _maxDelay);
                _timer = 0f;
            }
        }
    }
        public void SpawnFirePrefab()
    {
        int randomIndex = Random.Range(0, _spawnLocation.Count);
        Transform spawnLocation = _spawnLocation[randomIndex];
        DestroyFire newPrefab = Instantiate(_prefabToSpawn, spawnLocation.position, spawnLocation.rotation);
        _activePrefabs.Add(newPrefab);
        newPrefab.Destroyed += OnDestroyedPrefab;
    }
    public void OnDestroyedPrefab(DestroyFire prefab)
    {
        _activePrefabs.Remove(prefab);
        prefab.Destroyed -= OnDestroyedPrefab;
    }

    [SerializeField]
    private List<Transform> _spawnLocation;
    private List<DestroyFire> _activePrefabs = new List<DestroyFire>();

    [SerializeField]
    private DestroyFire _prefabToSpawn;

    private float _randomTimer = 5f;
    [Header("Timer for fire prefab")]
    [SerializeField]
    private float _minDelay = 1f;
    [SerializeField]
    private float _maxDelay = 5f;
    private float _timer = 0f;
    
}
