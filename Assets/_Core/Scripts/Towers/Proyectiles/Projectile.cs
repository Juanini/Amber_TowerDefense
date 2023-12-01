using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public GameObject visuals;
    
    private bool isActive;
    public bool IsActive => isActive;

    protected Enemy target;

    private int damage;

    public void Shot(Vector2 _shootPos, Enemy _target, int _damage = GameConst.TOWER_STANDARD_DAMAGE)
    {
        damage = _damage;
        isActive = true;
        SetTarget(_target);
        transform.position = _shootPos;
        visuals.gameObject.SetActive(true);
    }
    protected abstract void UpdateMovement();

    private void Update()
    {
        if (target != null)
        {
            UpdateMovement();
            CheckCollision();
        }
    }

    public void SetTarget(Enemy _enemy)
    {
        target = _enemy;
    }

    protected void CheckCollision()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 0.01f)
        {
            if (isActive)
            {
                target.DoDamage(damage);
            }

            Deactivate();
        }
    }

    private void Deactivate()
    {
        isActive = false;
        visuals.gameObject.SetActive(false);
    }
}