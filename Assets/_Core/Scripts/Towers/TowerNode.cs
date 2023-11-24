using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerNode : MonoBehaviour
{
    [BoxGroup("Elements")] public GameObject towerSpawnPos;
    
    [SerializeField] private TouchDetector touchDetector;

    private TowerNodeState towerNodeState;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        towerNodeState = TowerNodeState.Available;
        touchDetector.OnTouched += OnTowerNodeSelected;
    }

    private void OnTowerNodeSelected(PointerEventData _eventData)
    {
        LevelManager.Ins.towerNodeSelected = this;
        UI.Ins.ShowTowerCreationUI(transform.position);
    }

    public void SetState(TowerNodeState _towerNodeState)
    {
        towerNodeState = _towerNodeState;

        switch (towerNodeState)
        {
            case TowerNodeState.Available:
                touchDetector.Enable();
                break;
            
            case TowerNodeState.Busy:
                touchDetector.Disable();
                break;
        }
    }
}
