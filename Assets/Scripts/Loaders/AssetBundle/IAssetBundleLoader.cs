using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MWTP.Loaders
{
    public interface IAssetBundleLoader
    {
        UniTask<AssetBundle> LoadSpriteAsset();
    }
}