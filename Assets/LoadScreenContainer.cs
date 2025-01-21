using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using MWTP.UI;
using UnityEngine;

public class LoadScreenContainer : MonoBehaviour
{
    [SerializeField] private CanvasGroupBehaviour _canvasGroup;
    [SerializeField] private ProgressBar _progressBar;

    public void StartLoad()
    {
        _canvasGroup.SetActive(true);
        _progressBar.SetValue(0);
    }

    public void UpdateValue(float value)
    {
        _progressBar.SetValue(value);
    }

    public void StopLoad()
    {
        _canvasGroup.SetActive(false);
    }
}