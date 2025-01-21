using UnityEngine;

namespace Loader
{
    public static class LoadFilesConvertHelper
    {
        private const string BUTTON_BACKGROUND_SPRITE_NAME = "spanch_bob";
        
        public static T ConvertJsonToObject<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
        
        public static Sprite GetSpriteFromAssetBundle(this AssetBundle loadedAssetBundle)
        {
            if (loadedAssetBundle == null)
            {
                Debug.LogError("AssetBundle is not loaded!");
                return null;
            }
            
            var texture = loadedAssetBundle.LoadAsset<Texture2D>(BUTTON_BACKGROUND_SPRITE_NAME);
            if (texture == null)
            {
                Debug.LogError($"Texture2D '{BUTTON_BACKGROUND_SPRITE_NAME}' not found in AssetBundle!");
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