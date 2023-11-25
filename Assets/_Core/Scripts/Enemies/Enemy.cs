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
    
    public void Init()
    {
        health = enemyConfig.health;
        
        enemyHealthBar.Init(enemyConfig.health);
        isActive = true;
        MoveOnPath();
    }

    private void MoveOnPath()
    {
        Vector3[] worldPath = GameManager.Ins.LevelActive.path.path.wps;

        transform.position = worldPath[0];
        transform.DOPath(worldPath,60).SetEase(Ease.Linear).OnUpdate(OnPathUpdate);
    }

    public void DoDamage(int _damage)
    {
        health -= _damage;

        if (health <= 0)
        {
            Die();
            GiveGold();
        }
        
        enemyHealthBar.TakeDamage(_damage);
    }

    private void Die()
    {
        isActive = false;
        gameObject.gameObject.SetActive(false);
        GameManager.Ins.EnemyKilled();
    }

    private void GiveGold()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
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
