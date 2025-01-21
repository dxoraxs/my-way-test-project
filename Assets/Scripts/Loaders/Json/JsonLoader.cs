using Cysharp.Threading.Tasks;
using MWTP.Data;
using UnityEngine.Networking;

namespace MWTP.Loaders
{
    public class JsonLoader : IJsonLoader
    {
        private readonly string _settingsUrl;
        private readonly string _textsUrl;

        public JsonLoader(string settingsUrl, string textsUrl)
        {
            _settingsUrl = settingsUrl;
            _textsUrl = textsUrl;
        }

        public async UniTask<string> LoadSettings()
        {
            return await Load(_settingsUrl);
        }

        public async UniTask<string> LoadTexts()
        {
            return await Load(_textsUrl);
        }

        private static async UniTask<string> Load(string url)
        {
            using var request = UnityWebRequest.Get(url);
            await request.SendWebRequest().ToUniTask();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var resultJson = request.downloadHandler.text;
                return resultJson;
            }

            throw new System.Exception($"Failed to load JSON from {url}: {request.error}");
        }
    }
}