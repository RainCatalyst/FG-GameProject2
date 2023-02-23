using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SpaceGame;

public class FireSpawnManager : MonoSingleton<FireSpawnManager>
{
    protected override void Awake()
    {
        base.Awake();
        _availableLocations = new List<Transform>(_spawnLocation);
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameplayPaused)
            return;
        _timer += Time.deltaTime;
        if (_timer >= _randomTimer)
        {
            SpawnFire();
            _randomTimer = Random.Range(_minDelay, _maxDelay);
            _timer = 0f;
        }
    }
    
    public void SpawnFire()
    {
        if (!EncounterManager.CurrentEncounter.AllowFires)
            return;
        if (_availableLocations.Count == 0)
        {
            Debug.LogWarning("Can't spawn more fires!");
            return;
        }
        int locationIndex = Random.Range(0, _availableLocations.Count);
        Transform spawnLocation = _availableLocations[locationIndex];
        DestroyFire fireInstance = Instantiate(_prefabToSpawn, spawnLocation);
        _availableLocations.RemoveAt(locationIndex);
        fireInstance.Destroyed += OnFireDestroyed;
        _spawnClip.Play();
    }
        
    private void OnFireDestroyed(DestroyFire prefab)
    {
        _availableLocations.Add(prefab.transform.parent);
        prefab.Destroyed -= OnFireDestroyed;
    }

    [SerializeField]
    private List<Transform> _spawnLocation;
    private List<Transform> _availableLocations;

    [SerializeField]
    private DestroyFire _prefabToSpawn;
    [SerializeField]
    private AudioClipSO _spawnClip;

    private float _randomTimer = 5f;
    [Header("Timer for fire prefab")]
    [SerializeField]
    private float _minDelay = 1f;
    [SerializeField]
    private float _maxDelay = 5f;
    private float _timer;

}
