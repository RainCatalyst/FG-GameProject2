using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        // _overlay.GetComponent<Image>().color = Color.clear;
        // _text.localScale = Vector3.zero;
        // _restartButton.localScale = Vector3.zero;
        //
        // LeanTween.color(_overlay, new Color(0, 0, 0, 0.85f), 0.75f).setIgnoreTimeScale(true);
        // LeanTween.scale(_restartButton, Vector3.one, 0.21f).setEaseOutBack().setDelay(1.25f).setIgnoreTimeScale(true);
        // LeanTween.scale(_text, Vector3.one, 0.21f).setEaseOutBack().setDelay(1f).setIgnoreTimeScale(true);
    }

    public RectTransform _restartButton;
    public RectTransform _overlay;
    public RectTransform _text;
}
