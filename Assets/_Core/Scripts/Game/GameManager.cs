using System;
using System.Collections;
using System.Collections.Generic;
using GameEventSystem;
using HannieEcho.UI;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : StateMachine<GameState>
{
    public static GameManager Ins;

    private int playerLife;
    public int PlayerLife => playerLife;
    
    // * =====================================================================================================================================
    // * MAIN

    #region MAIN
    
    private void Awake()
    {
        Ins = this;
    }
    
    private async void Init()
    {
        await UI.Ins.Init();
        await UI.Ins.nav.ShowDialog<IngameView>();
        
        AddState( GameState.Idle,         new GS_Idle(GameState.Idle), this);
        AddState( GameState.CreateTower,  new GS_CreateTower(GameState.CreateTower), this);
        AddState( GameState.Win,          new GS_Win(GameState.Win),          this);
        AddState( GameState.Lose,         new GS_Lose(GameState.Lose),         this);
        
        // AddState( GameState.Paused,       new GS_Paused(GameState.Paused),       this);
        
        await EnterInitialState(States[GameState.Idle]);
    }

    private void Start()
    {
        Init();
    }
    
    #endregion

    public void OnEnemyInvaded(Enemy _enemy)
    {
        playerLife -= _enemy.GetAttackValue();

        if (playerLife < 0)
        {
            playerLife = 0;
        }
        
        GameEventManager.TriggerEvent(GameEvents.ENEMY_INVADED);
        CheckPlayerLife();
    }

    private void CheckPlayerLife()
    {
        if (playerLife <= 0)
        {
            TransitionToState(GameState.Lose);
        }
    }

    public void EnemyKilled()
    {
        
    }

    
    
    // * =====================================================================================================================================
    // * 

    public TowerType towerTypeToCreate;
    
    public void OnCreateTower(TowerType _towerType)
    {
        towerTypeToCreate = _towerType;
        
        TransitionToState(GameState.CreateTower);
    }
}
