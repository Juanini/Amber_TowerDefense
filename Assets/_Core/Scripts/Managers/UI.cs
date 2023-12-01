using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using HannieEcho.UI;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Ins;
    
    public UIManager uiManager;
    public UINavigation nav;
    public TowerOptionsUI towerOptionsUI;
    public Image fadePanel;

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
    
    // * =====================================================================================================================================
    // * FADE PANEL

    public async UniTask FadeInPanel()
    {
        SetFadePanelAlpha(0);
        await fadePanel.DOFade(1, 0.25f).AsyncWaitForCompletion();
    }
    
    public async UniTask FadeOutPanel()
    {
        SetFadePanelAlpha(1);
        await fadePanel.DOFade(0, 0.25f).AsyncWaitForCompletion();
    }

    private void SetFadePanelAlpha(int _value)
    {
        var c = fadePanel.color;
        c.a = _value;
        fadePanel.color = c;
    }
}

