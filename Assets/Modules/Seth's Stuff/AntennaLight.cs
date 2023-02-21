using System.Collections;
using System.Collections.Generic;
using SpaceGame;
using UnityEngine;
using UnityEngine.Timeline;

public class AntennaLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        _robotInteractable = GetComponent<RobotInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        _level = _robotInteractable._batteryLevel / 100f;
        _particle.startColor = _gradient.Evaluate(_level);
        _light.color = _gradient.Evaluate(_level);

        if (_level == 0)
        {
            Flashing();
        }
        else
        {
            _light.enabled = true;
        }
           
    }

    void Flashing()
    {
        if (_blinkTimer > 0)
            _blinkTimer -= Time.deltaTime;

        if (_blinkTimer <= 0)
        {
           // _particle.enableEmission = !_particle.enableEmission;
            _light.enabled = !_light.enabled;
            _blinkTimer = 0.5f;
        }
    }

    [SerializeField] private Light _light;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private float _level;
    [SerializeField] private RobotInteractable _robotInteractable;
    [SerializeField] private float _blinkTimer;
    [SerializeField] private ParticleSystem _particle;
}
