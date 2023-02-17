using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxSpeed);
    }

    [SerializeField] private float skyboxSpeed;
}
