using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        LeanTween.cancelAll();
        SceneManager.LoadScene("Game");
    }
    
    public void CreditsClicked()
    {
        _isClicked = true;
    }
    
    public void CreditsBack()
    {
        _isClicked = false;
    }

    private void Update()
    {
        if (_isClicked)
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, _camTarget.transform.position, _camSpeed * Time.deltaTime);
            _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation,_camTarget.transform.rotation, _camRotateSpeed * Time.deltaTime);
            _camera.transform.SetParent(_camTarget.transform);
        }
        else
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, _camOrigin.transform.position, _camSpeed / 2 * Time.deltaTime);
            _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation,_camOrigin.transform.rotation, _camRotateSpeed / 2 * Time.deltaTime);
            _camera.transform.SetParent(null);
        }
        
    }


    [SerializeField] 
    private GameObject _camera;
    [SerializeField] 
    private GameObject _camTarget;
    [SerializeField] 
    private GameObject _camOrigin;
    [SerializeField] 
    private float _camSpeed = 15f;
    [SerializeField] 
    private float _camRotateSpeed = 5f;

    private bool _isClicked;
}
