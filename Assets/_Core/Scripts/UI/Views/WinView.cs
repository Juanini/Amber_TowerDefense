using System.Collections;
using System.Collections.Generic;
using HannieEcho.UI;
using UnityEngine;
using UnityEngine.UI;

public class WinView : UIView
{
    public Button mainMenuButton;
    public Button restartButton;

    public override void OnViewCreated()
    {
        base.OnViewCreated();
        
        // mainMenuButton.onClick.AddListener(OnMainMenuClick);
        // restartButton.onClick.AddListener(OnRestartClick);
    }

    private void OnRestartClick()
    {
        
    }

    private void OnMainMenuClick()
    {
        
    }
}
