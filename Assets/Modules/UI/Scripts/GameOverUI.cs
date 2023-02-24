using System.Collections;
using System.Collections.Generic;
using SpaceGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        _restartButton.Select();
        _scoreText.text = $"Score: {GameManager.Instance.Score}";
        _hscoreText.text = $"Best: {GameManager.Instance.Highscore}";

        // _overlay.GetComponent<Image>().color = Color.clear;
        // _text.localScale = Vector3.zero;
        // _restartButton.localScale = Vector3.zero;
        //
        // LeanTween.color(_overlay, new Color(0, 0, 0, 0.85f), 0.75f).setIgnoreTimeScale(true);
        // LeanTween.scale(_restartButton, Vector3.one, 0.21f).setEaseOutBack().setDelay(1.25f).setIgnoreTimeScale(true);
        // LeanTween.scale(_text, Vector3.one, 0.21f).setEaseOutBack().setDelay(1f).setIgnoreTimeScale(true);
    }

    public Button _restartButton;
    public TMP_Text _scoreText;
    public TMP_Text _hscoreText;
    public RectTransform _overlay;
    public RectTransform _text;
}
