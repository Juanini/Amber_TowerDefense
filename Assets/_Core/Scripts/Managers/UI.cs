using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HannieEcho.UI;
using Sirenix.OdinInspector;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Ins;
    
    [BoxGroup("UI")] public UIManager uiManager;
    [BoxGroup("UI")] public UINavigation nav;
    [BoxGroup("UI")] public TowerOptionsUI towerOptionsUI;

    // * =====================================================================================================================================
    // * MAIN
    
    private void Awake()
    {
        Ins = this;
    }

    public async UniTask Init()
    {
        await uiManager.Init();
        towerOptionsUI.Init();
    }

    // * =====================================================================================================================================
    // * 
    
    public void ShowTowerCreationUI(Vector2 _pos)
    {
        towerOptionsUI.ShowTowerCreationUI(_pos);
    }
    
    // * =====================================================================================================================================
    // * 

    public void ShowTowerOptions(Tower _tower)
    {
        towerOptionsUI.ShowTowerOptions(_tower);
    }
}
