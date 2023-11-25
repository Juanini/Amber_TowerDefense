using System.Collections;
using System.Collections.Generic;
using HannieEcho.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectView : UIView
{
    [BoxGroup("Elements")] public GameObject levelsContainer;
    [BoxGroup("Elements")] public GameObject levelsContainerOutPos;
    [BoxGroup("Elements")] public GameObject levelsContainerInPos;

    [BoxGroup("Level Buttons")] public Button level1Button;
    [BoxGroup("Level Buttons")] public Button level2Button;

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
