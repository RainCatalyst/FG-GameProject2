using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ValueLabel : MonoBehaviour
{
    [SerializeField] IntEventChannelSO valueEvent;
    [SerializeField] string text;

    TextMeshProUGUI textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        valueEvent.ValueUpdated += ValueUpdated;
    }

    void OnDisable()
    {
        valueEvent.ValueUpdated -= ValueUpdated;
    }

    void ValueUpdated(int value) => textMesh.text = $"{text}{value}";
}