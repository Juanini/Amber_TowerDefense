using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyConfig enemyConfig;
    public EnemyHealthBar enemyHealthBar;

    public void Init()
    {
        enemyHealthBar.ResetHealth();
    }
    
    private void Update()
    {
        transform.position += Vector3.right * (1f * Time.deltaTime);
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
}
