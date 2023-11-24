using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    [BoxGroup("Properties")] public TowerConfig towerConfig;
    
    [BoxGroup("Elements")][SerializeField] private TouchDetector touchDetector;

    protected List<Enemy> enemiesInRange = new List<Enemy>();

    protected virtual void OnEnemyEnter() { }
    protected virtual void OnEnemyExit() { }

    protected void Init()
    {
        touchDetector.OnTouched += OnTowerSelected;
    }

    private void OnTowerSelected(PointerEventData _eventData)
    {
        UI.Ins.ShowTowerOptions(this);
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConst.TAG_ENEMY))
        {
            enemiesInRange.Add(other.gameObject.GetComponent<Enemy>());
            OnEnemyEnter();
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(GameConst.TAG_ENEMY))
        {
            enemiesInRange.Remove(other.gameObject.GetComponent<Enemy>());
            OnEnemyExit();
        }
    }
}
