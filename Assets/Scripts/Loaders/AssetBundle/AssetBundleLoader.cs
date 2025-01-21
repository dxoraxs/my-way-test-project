using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MWTP.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace MWTP.Loaders
{
    public class AssetBundleLoader : IAssetBundleLoader
    {
        private readonly string _spriteUrl;
        private readonly List<AssetBundle> _loadedBundles = new();

        public AssetBundleLoader(string urlData)
        {
            _spriteUrl = urlData;
        }

        public async UniTask<AssetBundle> LoadSpriteAsset()
        {
            return await LoadAssetBundle(_spriteUrl);
        }

        public void ReleaseLoadedAsset()
        {
            foreach (var loadedBundle in _loadedBundles)
            {
                loadedBundle.Unload(true);
            }
            _loadedBundles.Clear();
        }

        private async UniTask<AssetBundle> LoadAssetBundle(string url)
        {
            using var request = UnityWebRequestAssetBundle.GetAssetBundle(url);

            await request.SendWebRequest().ToUniTask();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var loadAssetBundle = DownloadHandlerAssetBundle.GetContent(request);
                _loadedBundles.Add(loadAssetBundle);
                return loadAssetBundle;
            }

            throw new System.Exception($"Failed to load Asset Bundle: {request.error}");
        }
    }
}