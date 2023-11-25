using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class AttackTower : Tower
{
    [BoxGroup("Elements")] public GameObject shotPos;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public Enemy enemyTarget;
    
    private void Start()
    {
        base.Init();
        Init();
    }

    private new void Init()
    {
        fireCountdown = towerConfig.fireCount;
        fireRate = towerConfig.fireRate;
    }

    void Update()
    {
        if (enemiesInRange.Count <= 0) { return; }
        
        UpdateTarget();

        if (fireCountdown <= 0f && enemyTarget != null)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;

        foreach (Enemy enemy in enemiesInRange)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= towerConfig.range)
        {
            enemyTarget = nearestEnemy;
        }
        else
        {
            enemyTarget = null;
        }
    }

    private async void Shoot()
    {
        var projectile = await AssetsManager.Ins.GetProjectile(towerConfig.projectileType);
        projectile.Shot( shotPos.transform.position, enemyTarget, towerConfig.projectileDamage);
    }

    // Dibujar el rango de la torre en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerConfig.range);
    }
}

