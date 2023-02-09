using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float Progress
    {
        get => _progress;
        set
        {
            _progress = value;
            if (_useGradient)
                _progressFill.color = _colorOverProgress.Evaluate(value);
            _slider.value = _progress;
        }
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    [SerializeField]
    private bool _useGradient;
    [SerializeField]
    private Gradient _colorOverProgress;
    [SerializeField]
    private Image _progressFill;
    
    private Slider _slider;
    private float _progress;
}
