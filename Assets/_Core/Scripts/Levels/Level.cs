using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using Sirenix.OdinInspector;
using UnityEngine;

public class Level : MonoBehaviour
{
    [BoxGroup("Properties")] public LevelConfig levelConfig;
    [BoxGroup("Properties")] public DOTweenPath path;
    

    private async void Start()
    {
        await GameManager.Ins.OnLevelLoaded(this);
        SpawnEnemies();
    }

    private async UniTask SpawnEnemies()
    {
        Trace.Log(this.name + " - " + "Spawn Enemies");
        
        foreach (var enemyToSpawn in levelConfig.enemiesToSpawn)
        {
            var enemy = await AssetsManager.Ins.GetEnemy(enemyToSpawn);
            enemy.Init();

            await UniTask.Delay(levelConfig.spawnTime);
        }
    }
}
