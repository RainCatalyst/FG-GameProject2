using UnityEngine;
using TMPro;

namespace SpaceGame
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ValueLabel : MonoBehaviour
    {
        private void Awake() => _textMesh = GetComponent<TextMeshProUGUI>();
        private void OnEnable() => _eventChannel.EventRaised += UpdateText;
        private void OnDisable() => _eventChannel.EventRaised -= UpdateText;
        private void UpdateText(int value) => _textMesh.text = $"{_extraText}{value}";

        [SerializeField]
        private IntEventChannel _eventChannel;
        [SerializeField]
        private string _extraText;

        private TextMeshProUGUI _textMesh;
    }
}