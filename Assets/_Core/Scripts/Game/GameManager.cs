using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameEventSystem;
using HannieEcho.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StateMachine<GameState>
{
    public static GameManager Ins;

    private int playerHealth;
    public int PlayerHealth => playerHealth;
    
    private int playerGold;
    public int PlayerGold => playerGold;

    private Level levelActive;
    public Level LevelActive => levelActive;
    
    [HideInInspector] public TowerType towerTypeToCreate;
    
    public Enemy enemyTest;

    // * =====================================================================================================================================
    // * MAIN

    #region MAIN
    
    private void Awake()
    {
        Ins = this;
    }
    
    private void Start()
    {
        Init();
    }
    
    private async void Init()
    {
        await UI.Ins.Init();
        await UI.Ins.nav.ShowDialog<IngameView>();

        await LoadSceneAsync(GameConst.LEVEL_1);

        AddState( GameState.Idle,         new GS_Idle(GameState.Idle), this);
        AddState( GameState.CreateTower,  new GS_CreateTower(GameState.CreateTower), this);
        AddState( GameState.Win,          new GS_Win(GameState.Win),          this);
        AddState( GameState.Lose,         new GS_Lose(GameState.Lose),         this);
        
        // AddState( GameState.Paused,       new GS_Paused(GameState.Paused),       this);
        
        await EnterInitialState(States[GameState.Idle]);
    }

    #endregion
    
    // * =====================================================================================================================================
    // * LEVELS
    
    public async UniTask OnLevelLoaded(Level _level)
    {
        
        levelActive = _level;
        playerHealth = levelActive.levelConfig.PlayerHealth;
        playerGold = levelActive.levelConfig.InitialGold;
        
        await UI.Ins.FadeOutPanel();

        GameEventManager.TriggerEvent(GameEvents.UPDATE_INGAME_UI);

        enemyTest.Init();
    }
    
    public async UniTask LoadSceneAsync(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).ToUniTask();
    }
    
    // * =====================================================================================================================================
    // * FLOW

    public void OnEnemyInvaded(Enemy _enemy)
    {
        Trace.Log(this.name + " - " + "ENEMY INVADED!");
        playerHealth -= _enemy.GetAttackValue();

        if (playerHealth < 0)
        {
            playerHealth = 0;
        }
        
        GameEventManager.TriggerEvent(GameEvents.ENEMY_INVADED);
        GameEventManager.TriggerEvent(GameEvents.UPDATE_INGAME_UI);
        
        CheckPlayerLife();
    }

    private void CheckPlayerLife()
    {
        if (playerHealth <= 0)
        {
            TransitionToState(GameState.Lose);
        }
    }

    public void EnemyKilled()
    {
        
    }
    
    // * =====================================================================================================================================
    // * TOWERS

    public void OnCreateTower(TowerType _towerType)
    {
        towerTypeToCreate = _towerType;
        
        TransitionToState(GameState.CreateTower);
    }
    
    
}
