using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    public TowerConfig towerConfig;
    
    [SerializeField] private TouchDetector touchDetector;
    [SerializeField] private CircleCollider2D collider2D;

    protected List<Enemy> enemiesInRange = new List<Enemy>();

    protected virtual void OnEnemyEnter() { }
    protected virtual void OnEnemyExit() { }

    protected void Init()
    {
        touchDetector.OnTouched += OnTowerSelected;
        collider2D.radius = towerConfig.range;
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

    public void Remove()
    {
        Destroy(gameObject);
    }
}
