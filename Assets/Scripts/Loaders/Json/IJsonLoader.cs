using Cysharp.Threading.Tasks;

namespace MWTP.Loaders
{
    public interface IJsonLoader
    {
        UniTask<string> LoadSettings();
        UniTask<string> LoadTexts();
    }
}