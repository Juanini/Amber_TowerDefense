using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "Config/Tower Config", order = 1)]
public class TowerConfig : ScriptableObject
{
    [BoxGroup("Properties")] public float range;
    [BoxGroup("Properties")] public ProjectileType projectileType;
    
    [BoxGroup("Attack Tower")] public int projectileDamage;
    [BoxGroup("Attack Tower")] public int fireRate;
    [BoxGroup("Attack Tower")] public int fireCount;

}
