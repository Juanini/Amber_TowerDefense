using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Ins;

    [HideInInspector] public TowerNode towerNodeSelected;

    private List<Tower> levelTowerList;
    
    
    private void Awake()
    {
        Ins = this;
    }

    // * =====================================================================================================================================
    // * TOWERS

    #region TOWERS
    
    public async UniTask AddTower(TowerType _towerType)
    {
        var tower = await AssetsManager.Ins.GetTowerAssetByType(_towerType);
        
        towerNodeSelected.SetState(TowerNodeState.Busy);
        tower.transform.position = towerNodeSelected.towerSpawnPos.transform.position;
        tower.transform.parent = towerNodeSelected.transform;
    }
    
    #endregion
}
