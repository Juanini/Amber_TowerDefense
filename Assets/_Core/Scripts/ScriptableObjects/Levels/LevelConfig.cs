using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/Level Config", order = 1)]
public class LevelConfig : ScriptableObject
{
    public string sceneName;
    
    public int PlayerHealth;
    public int InitialGold;
    public int NumberOfWaves;
    
    public int spawnTime = 1500;
    public List<EnemyType> enemiesToSpawn;
}
