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
            _slider.value = _progress;
        }
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private Slider _slider;
    private float _progress;
}
