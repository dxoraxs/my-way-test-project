using UnityEngine;

namespace Loader
{
    public static class LoadFilesConvertHelper
    {
        public static T ConvertJsonToObject<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
        
        public static Sprite GetSpriteFromAssetBundle(this AssetBundle loadedAssetBundle, string assetName)
        {
            if (loadedAssetBundle == null)
            {
                Debug.LogError("AssetBundle is not loaded!");
                return null;
            }
            
            var texture = loadedAssetBundle.LoadAsset<Texture2D>(assetName);
            if (texture == null)
            {
                Debug.LogError($"Texture2D '{assetName}' not found in AssetBundle!");
                return null;
            }

            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );
        }
    }
}