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
    private IJsonLoader _jsonLoader;
    private IAssetBundleLoader _assetBundleLoader;

    private void Start()
    {
        _jsonLoader = new JsonLoader(_urlFilesData.Settings, _urlFilesData.Texts);
        _assetBundleLoader = new AssetBundleLoader(_urlFilesData.Sprite);

        LoadGameFiles();
    }

    private async void LoadGameFiles()
    {
        _loadScreenContainer.ShowScreen();
        
        var settingsJson = await _jsonLoader.LoadSettings();
        var settings = LoadFilesConvertHelper.ConvertJsonToObject<SettingsConfig>(settingsJson);
        _loadScreenContainer.UpdateValue(1/3f);
        
        await UniTask.Delay(1000);

        var textsJson = await _jsonLoader.LoadTexts();
        var texts = LoadFilesConvertHelper.ConvertJsonToObject<TextsConfig>(textsJson);
        _loadScreenContainer.UpdateValue(2/3f);
        
        await UniTask.Delay(1000);

        _assetBundleLoader.ReleaseLoadedAsset();
        var spriteAssetBundle = await _assetBundleLoader.LoadSpriteAsset();
        var sprite = spriteAssetBundle.GetSpriteFromAssetBundle();
        _loadScreenContainer.UpdateValue(1);

        await UniTask.Delay(1000);
        
        _loadScreenContainer.HideScreen();
    }
}