using System.Collections;
using System.Collections.Generic;
using HannieEcho.UI;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : UIView
{
    [SerializeField] private Button playButton;
    [SerializeField] private Image logoImage;

    public override void OnViewCreated()
    {
        base.OnViewCreated();
        playButton.onClick.AddListener(OnPlayClick);
    }

    private void OnPlayClick()
    {
        
    }
}
