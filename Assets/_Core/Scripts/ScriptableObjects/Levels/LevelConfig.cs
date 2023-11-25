using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/Level Config", order = 1)]
public class LevelConfig : ScriptableObject
{
    [BoxGroup("Properties")] public int PlayerHealth;
    [BoxGroup("Properties")] public int InitialGold;
    [BoxGroup("Properties")] public int NumberOfWaves;

    [InfoBox("In Milliseconds")]
    [BoxGroup("Enemies")] public int spawnTime = 1500;
    [BoxGroup("Enemies")] public List<EnemyType> enemiesToSpawn;
}
