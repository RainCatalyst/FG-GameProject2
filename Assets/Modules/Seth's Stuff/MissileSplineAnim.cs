using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class MissileSplineAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _splineAnimate.ElapsedTime = _progressBar.Progress;
    }

    [SerializeField] private Spline _spline;
    [SerializeField] private SplineAnimate _splineAnimate;
    [SerializeField] private ProgressBar _progressBar;

}
