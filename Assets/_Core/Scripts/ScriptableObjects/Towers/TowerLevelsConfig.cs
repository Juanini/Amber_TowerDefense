using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TowerLevelConfig", menuName = "Config/Tower Level Config", order = 1)]
public class TowerLevelsConfig : ScriptableObject
{
    public List<AssetReference> towerLevels;
}
