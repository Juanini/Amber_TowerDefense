using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyConfig enemyConfig;
    [SerializeField] private GameObject visuals;

    public EnemyType enemyType;
    
    public EnemyHealthBar enemyHealthBar;

    private Vector2 lastPosition;
    
    private Direction facingDirection = Direction.RIGHT;
    public Direction FacingDirection => facingDirection;

    private bool isActive;
    public bool IsActive => isActive;

    private int health;

    private Tween pathTween;
    
    public void Init()
    {
        health = enemyConfig.health;
        
        enemyHealthBar.Init(enemyConfig.health);
        isActive = true;
        MoveOnPath();
        
        gameObject.SetActive(true);
    }

    private void MoveOnPath()
    {
        Vector3[] worldPath = GameManager.Ins.LevelActive.path.path.wps;

        transform.position = worldPath[0];

        var speed = (float)GameConst.ENEMY_PATH_MOVEMENT;
        speed *= GetSpeedMultiply(enemyConfig.speedType);

        KillPath();
        pathTween = transform.DOPath(worldPath,speed).SetEase(Ease.Linear).OnUpdate(OnPathUpdate);
    }

    private void KillPath()
    {
        if (pathTween.IsActive())
        {
            pathTween.Kill();
        }
    }

    private float GetSpeedMultiply(EnemySpeedType _speedType)
    {
        switch (_speedType)
        {
            case EnemySpeedType.Slow:
                return GameConst.ENEMY_PATH_MOVEMENT_SLOW;
                
            case EnemySpeedType.Normal:
                default:
                return GameConst.ENEMY_PATH_MOVEMENT_NORMAL;

            case EnemySpeedType.Fast:
                return GameConst.ENEMY_PATH_MOVEMENT_FAST;
        }
    }

    public void DoDamage(int _damage)
    {
        health -= _damage;

        if (health <= 0)
        {
            Die();
            GiveGold();
            GameManager.Ins.EnemyKilled();
        }
        
        enemyHealthBar.TakeDamage(_damage);
    }

    private void Die()
    {
        KillPath();
        isActive = false;
        gameObject.gameObject.SetActive(false);
    }

    private void GiveGold()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isActive) { return; }
        
        if (col.CompareTag(GameConst.TAG_PLAYER))
        {
            Die();
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
