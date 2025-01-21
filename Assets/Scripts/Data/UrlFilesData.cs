using UnityEngine;

namespace MWTP.Data
{
    [CreateAssetMenu(fileName = "url", menuName = "Url Data", order = 0)]
    public class UrlFilesData : ScriptableObject
    {
        [field:SerializeField] public string Settings { get; private set; }
        [field:SerializeField] public string Texts { get; private set; }
        [field:SerializeField] public string Sprite { get; private set; }
    }
}