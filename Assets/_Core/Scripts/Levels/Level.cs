using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using Sirenix.OdinInspector;
using UnityEngine;

public class Level : MonoBehaviour
{
    [BoxGroup("Properties")] public LevelConfig levelConfig;
    [BoxGroup("Properties")] public DOTweenPath path;
    

    private void Start()
    {
        GameManager.Ins.OnLevelLoaded(this);
    }
}
