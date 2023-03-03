using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{

    void Start(){
        SetRandomTime();
        _time = _minTime;
    }
 
    void FixedUpdate(){
 
        //Counts up
        _time += Time.deltaTime;
 
        //Check if its the right time to spawn the object
        if(_time >= _spawnTime){
            SpawnObject();
            SetRandomTime();
        }
    }
    
    //Spawns the object and resets the time
    void SpawnObject(){
        _time = _minTime;
        Vector3 randomPos = Random.insideUnitSphere * _radius;

        Instantiate(_asteroid, this.transform.position + randomPos, Random.rotation);
    }
 
    //Sets the random time between minTime and maxTime
    void SetRandomTime(){
        _spawnTime = Random.Range(_minTime, _maxTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
            
            Gizmos.DrawWireSphere(this.transform.position, _radius);
    }


    [SerializeField] 
    private GameObject _asteroid;
    [SerializeField] 
    private float _maxTime = 5;
    [SerializeField] 
    private float _minTime = 2;
    [SerializeField] 
    private float _radius = 2;
    
    private float _time;
    private float _spawnTime;

    private Vector3 _randomSpawn;

}
