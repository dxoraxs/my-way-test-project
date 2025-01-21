using UnityEngine;

namespace MWTP.UI.Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroupBehaviour _canvasGroup;
        
        public virtual void ShowScreen()
        {
            _canvasGroup.SetActive(true);
        }

        public virtual void HideScreen()
        {
            _canvasGroup.SetActive(false);
        }
    }
}