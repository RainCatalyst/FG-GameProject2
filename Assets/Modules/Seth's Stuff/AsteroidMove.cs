using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(_speedMin, _speedMax);
        Destroy(gameObject, 45f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    private float _speed;
    
    [SerializeField]
    private float _speedMin = 2f;
    [SerializeField]
    private float _speedMax = 12f;
}
