using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/Level Config", order = 1)]
public class LevelConfig : ScriptableObject
{
    [ValueDropdown("GetLevelNames")]
    [BoxGroup("Scene")] public string sceneName;
    
    [BoxGroup("Properties")] public int PlayerHealth;
    [BoxGroup("Properties")] public int InitialGold;
    [BoxGroup("Properties")] public int NumberOfWaves;

    [InfoBox("In Milliseconds")]
    [BoxGroup("Enemies")] public int spawnTime = 1500;
    [BoxGroup("Enemies")] public List<EnemyType> enemiesToSpawn;
    
    private static readonly ValueDropdownList<string> GetLevelNames = new ValueDropdownList<string>()
    {
        { "Level 1", GameConst.LEVEL_1 },
        { "Level 2", GameConst.LEVEL_2 }
    };
}
