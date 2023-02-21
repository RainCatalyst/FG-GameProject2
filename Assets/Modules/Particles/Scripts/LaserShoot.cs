using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{

    public class LaserShoot : MonoBehaviour
    {
        public void PlayParticle()
        { 
            ParticleSystem[] subParticles = GetComponentsInChildren<ParticleSystem>();

            foreach (ParticleSystem subParticle in subParticles)
            {
                subParticle.Play();
            }
        }


    [SerializeField] private ParticleSystem _turretLaser;
    }

}