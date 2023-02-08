using System.Collections;
using UnityEngine;
using System;

public class DestroyFire : MonoBehaviour
{
    public event Action<DestroyFire> Destroyed;

    private void Start()
    { 
        StartCoroutine(DestroyAfterTime());
    }
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(_fireTimer);
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }

    [SerializeField]
    private float _fireTimer = 20f;
}