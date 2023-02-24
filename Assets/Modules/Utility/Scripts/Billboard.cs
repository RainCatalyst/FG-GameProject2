using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Awake()
    {
        _camera = Camera.main;
    }
    
    void LateUpdate()
    {
        // Vector3 right = transform.right; // Fixed right
        // Vector3 forward = Vector3.ProjectOnPlane(_camera.transform.forward, right).normalized;
        // Vector3 up = Vector3.Cross(forward, right); // Compute the up vector
        // transform.rotation = Quaternion.LookRotation(forward, up);
        // transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(_camera.transform.forward, transform.up).normalized, transform.up);
        transform.LookAt(_camera.transform);
        transform.Rotate(0, 180, 0);
    }
    
    private Camera _camera;
}
