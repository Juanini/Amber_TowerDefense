using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using GameEventSystem;
using HannieEcho.UI;
using UnityEngine;

public class IngameView : UIView
{
    public IconWithInfo playerHealth;
    public IconWithInfo playerGold;
    public IconWithInfo enemyWaves;
    
    public override void OnViewCreated()
    {
        base.OnViewCreated();
        GameEventManager.StartListening(GameEvents.UPDATE_INGAME_UI, UpdateIngameUI);

        playerHealth.Init();
        playerGold.Init();
        enemyWaves.Init();
    }

    private void OnDestroy()
    {
        GameEventManager.StopListening(GameEvents.UPDATE_INGAME_UI, UpdateIngameUI);
    }

    private void UpdateIngameUI(Hashtable arg0)
    {
        playerHealth.UpdateValue(GameManager.Ins.PlayerHealth);
        playerGold.UpdateValue(GameManager.Ins.PlayerGold);
    }
}
