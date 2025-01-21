using Cysharp.Threading.Tasks;
using MWTP.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace MWTP.Loaders
{
    public class AssetBundleLoader : IAssetBundleLoader
    {
        private readonly string _spriteUrl;

        public AssetBundleLoader(UrlFilesData urlData)
        {
            _spriteUrl = urlData.Sprite;
        }

        public async UniTask<AssetBundle> LoadSpriteAsset()
        {
            return await LoadAssetBundle(_spriteUrl);
        }
        
        private static async UniTask<AssetBundle> LoadAssetBundle(string url)
        {
            using var request = UnityWebRequestAssetBundle.GetAssetBundle(url);

            await request.SendWebRequest().ToUniTask();

            if (request.result == UnityWebRequest.Result.Success)
            {
                return DownloadHandlerAssetBundle.GetContent(request);
            }

            throw new System.Exception($"Failed to load Asset Bundle: {request.error}");
        }
    }
}