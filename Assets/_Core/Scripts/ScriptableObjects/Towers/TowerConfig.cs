using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "Config/Tower Config", order = 1)]
public class TowerConfig : ScriptableObject
{
    public float range;
    public ProjectileType projectileType;
    
    public int projectileDamage;
    public int fireRate;
    public int fireCount;

}
