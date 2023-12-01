using System.Collections;
using System.Collections.Generic;
using HannieEcho.UI;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectView : UIView
{
    public GameObject levelsContainer;
    public GameObject levelsContainerOutPos;
    public GameObject levelsContainerInPos;

    public Button level1Button;
    public Button level2Button;

    public override void OnViewCreated()
    {
        base.OnViewCreated();

        level1Button.onClick.AddListener(() => OnPlayLevel(1));
        level2Button.onClick.AddListener(() => OnPlayLevel(2));
    }

    private void OnPlayLevel(int _level)
    {
        
    }
}
