using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserImpact : MonoBehaviour
{
    public GameObject Fire;
    public LineRenderer Laser;
    public ParticleSystem Glow;
    public ParticleSystem Sparks1;
    public ParticleSystem Sparks2;

    private void Awake()
    {
        Play();
    }

    public void Play()
    {
        LeanTween.delayedCall(0.25f, () =>
        {
            Laser.gameObject.SetActive(false);
            Glow.Stop();
            Sparks1.Stop();
            Sparks2.Stop();
        });
        LeanTween.value(gameObject, f =>
        {
            Laser.widthMultiplier = f;
        }, 0f, 0.25f, 0.15f).setEaseInQuad();//.setOnComplete(() => Laser.gameObject.SetActive(false));
        LeanTween.delayedCall(0.175f, () => Fire.SetActive(true));
    }
}
