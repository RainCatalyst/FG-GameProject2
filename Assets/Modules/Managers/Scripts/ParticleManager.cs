using System;
using UnityEngine;

namespace SpaceGame
{
    public enum ParticleType
    {
        None,
        Explosion,
        TurretShot
    }
    
    public class ParticleManager : MonoSingleton<ParticleManager>
    {
        public void Spawn(ParticleType type, Vector3 position, Transform overrideParent = null)
        {
            var prefab = GetParticleObject(type);
            if (prefab)
                Instantiate(prefab, position, Quaternion.identity, overrideParent);
        }
        
        private GameObject GetParticleObject(ParticleType type) => type switch
        {
            ParticleType.None => null,
            ParticleType.Explosion => _explosion,
            ParticleType.TurretShot => _turretShot,
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"VfxType not found: {type}"),
        };
        
        [Header("Particles")]
        [SerializeField]
        private GameObject _explosion;
        [SerializeField]
        private GameObject _turretShot;
    }
}