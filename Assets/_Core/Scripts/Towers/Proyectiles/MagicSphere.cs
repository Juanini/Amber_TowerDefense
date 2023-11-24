using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : Projectile
{
    protected override void UpdateMovement()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * (4 * Time.deltaTime);
        }
    }
}
