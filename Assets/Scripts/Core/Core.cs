using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Loader;
using MWTP.Data;
using MWTP.Loaders;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private UrlFilesData _urlFilesData;
    [SerializeField] private LoadScreenContainer _loadScreenContainer;
    [SerializeField] private GameScreenContainer _gameScreenContainer;
    private IJsonLoader _jsonLoader;
    private IAssetBundleLoader _assetBundleLoader;
    private SettingsConfig _settingsConfig;
    private TextsConfig _textsConfig;
    private Sprite _buttonBackgroundSprite;

    private int _clickCounter;

    private void Start()
    {
        _jsonLoader = new JsonLoader(_urlFilesData.Settings, _urlFilesData.Texts);
        _assetBundleLoader = new AssetBundleLoader(_urlFilesData.Sprite);

        InitializeGame();
    }

    private async void InitializeGame()
    {
        await LoadGameFiles();
        InitializeGameScreen();
    }

    private async UniTask LoadGameFiles()
    {
        _loadScreenContainer.ShowScreen();
        
        var settingsJson = await _jsonLoader.LoadSettings();
        _settingsConfig = LoadFilesConvertHelper.ConvertJsonToObject<SettingsConfig>(settingsJson);
        _clickCounter = SaveDataController.LoadCounter(_settingsConfig.startingNumber);
        _loadScreenContainer.UpdateValue(1/3f);
        
        await UniTask.Delay(500);

        var textsJson = await _jsonLoader.LoadTexts();
        _textsConfig = LoadFilesConvertHelper.ConvertJsonToObject<TextsConfig>(textsJson);
        _loadScreenContainer.UpdateValue(2/3f);
        
        await UniTask.Delay(500);

        _assetBundleLoader.ReleaseLoadedAsset();
        var spriteAssetBundle = await _assetBundleLoader.LoadSpriteAsset();
        _buttonBackgroundSprite = spriteAssetBundle.GetSpriteFromAssetBundle();
        _loadScreenContainer.UpdateValue(1);

        await UniTask.Delay(1000);
        
        _loadScreenContainer.HideScreen();
    }

    private void InitializeGameScreen()
    {
        _gameScreenContainer.ShowScreen();
        _gameScreenContainer.SetWelcomeText(_textsConfig.welcomeMessage);
        _gameScreenContainer.UpdateCounterText(_clickCounter);
        _gameScreenContainer.SetButtonBackgroundSprite(_buttonBackgroundSprite);

        _gameScreenContainer.OnClickIncrement += IncrementCounter;
        _gameScreenContainer.OnClickRefresh += RefreshData;
    }

    private void RefreshData()
    {
        _gameScreenContainer.HideScreen();
        _gameScreenContainer.OnClickIncrement -= IncrementCounter;
        _gameScreenContainer.OnClickRefresh -= RefreshData;
        
        SaveDataController.DeleteCounter();
        InitializeGame();
    }

    private void OnApplicationQuit()
    {
        SaveDataController.SaveCounter(_clickCounter);
    }

    private void IncrementCounter()
    {
        _clickCounter++;
        _gameScreenContainer.UpdateCounterText(_clickCounter);
    }
}