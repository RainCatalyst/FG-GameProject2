using System.Collections;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{

    private void OnEnable()
    {
        manager = GetComponentInParent<FireSpawnManager>();
        
        StartCoroutine(DestroyAfterTime());
        
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(_fireTimer);
        manager.OnDestroyedPrefab(this.gameObject);
        Debug.Log("DESTROYEEDDDDD");

    }

    FireSpawnManager manager;
    [SerializeField]
    private float _fireTimer = 20f;
}