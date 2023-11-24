using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyConfig enemyConfig;
    [SerializeField] private GameObject visuals;
    
    public EnemyHealthBar enemyHealthBar;

    private Vector2 lastPosition;
    
    private Direction facingDirection = Direction.RIGHT;
    public Direction FacingDirection => facingDirection;
    
    public void Init()
    {
        enemyHealthBar.Init(enemyConfig.health);
        MoveOnPath();
    }

    private void MoveOnPath()
    {
        Vector3[] worldPath = GameManager.Ins.LevelActive.path.path.wps;

        transform.position = worldPath[0];
        transform.DOPath(worldPath,60).SetEase(Ease.Linear).OnUpdate(OnPathUpdate);
    }

    public void DecreaseLife()
    {
        Trace.Log(this.name + " - " + "Decrease Life");
        enemyHealthBar.TakeDamage(20);
    }

    public void DoDamage()
    {
        DecreaseLife();   
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameConst.TAG_PLAYER))
        {
            GameManager.Ins.OnEnemyInvaded(this);
        }
    }

    public int GetAttackValue()
    {
        return enemyConfig.attackValue;
    }
    
    void OnPathUpdate() 
    {
        Vector2 currentPosition = transform.position;

        if (currentPosition.x > lastPosition.x) 
        {
            facingDirection = Direction.RIGHT;
        } 
        else if (currentPosition.x < lastPosition.x)
        {
            facingDirection = Direction.LEFT;
        }
        
        Game.SetFacingDirection(visuals.transform,facingDirection);
        lastPosition = currentPosition;
    }
    
    
}
