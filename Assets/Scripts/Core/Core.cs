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
        _loadScreenContainer.UpdateValue(1/3f);
        
        await UniTask.Delay(1000);

        var textsJson = await _jsonLoader.LoadTexts();
        _textsConfig = LoadFilesConvertHelper.ConvertJsonToObject<TextsConfig>(textsJson);
        _loadScreenContainer.UpdateValue(2/3f);
        
        await UniTask.Delay(1000);

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
        _gameScreenContainer.UpdateCounterText(_settingsConfig.startingNumber);
        _gameScreenContainer.SetButtonBackgroundSprite(_buttonBackgroundSprite);
    }
}