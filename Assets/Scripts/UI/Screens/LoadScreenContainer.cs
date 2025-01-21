using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using MWTP.UI;
using MWTP.UI.Screens;
using UnityEngine;

public class LoadScreenContainer : BaseScreen
{
    [SerializeField] private ProgressBar _progressBar;

    public override void ShowScreen()
    {
        base.ShowScreen();
        _progressBar.SetValue(0);
    }

    public void UpdateValue(float value)
    {
        _progressBar.SetValue(value);
    }
}