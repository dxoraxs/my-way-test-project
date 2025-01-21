using System;
using System.Collections;
using System.Collections.Generic;
using MWTP.UI.Screens;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenContainer : BaseScreen
{
    public event Action OnClickIncrement;
    public event Action OnClickRefresh;
    [SerializeField] private Image _incrementButtonImage;
    [SerializeField] private TMP_Text _welcome;
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private Button _incrementButton;
    [SerializeField] private Button _refreshButton;

    private void Start()
    {
        _incrementButton.onClick.AddListener(OnClickIncrementButton);
        _refreshButton.onClick.AddListener(OnClickRefreshButton);
    }

    public void SetButtonBackgroundSprite(Sprite sprite)
    {
        _incrementButtonImage.sprite = sprite;
    }

    public void SetWelcomeText(string text)
    {
        _welcome.text = text;
    }

    public void UpdateCounterText(int counter)
    {
        _counter.text = counter.ToString();
    }

    private void OnClickIncrementButton()
    {
        OnClickIncrement?.Invoke();
    }

    private void OnClickRefreshButton()
    {
        OnClickRefresh?.Invoke();
    }
}