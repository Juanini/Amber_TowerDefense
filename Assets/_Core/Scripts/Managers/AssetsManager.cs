using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

public class AssetsManager : SerializedMonoBehaviour
{
    public static AssetsManager Ins;

    [BoxGroup("Projectiles")][SerializeField] private AssetReference projectileArrow;
    [BoxGroup("Projectiles")][SerializeField] private AssetReference projectileMagic;
    
    [BoxGroup("Towers")][SerializeField] private TowerLevelsConfig towersLevelsConfig_Archer;
    [BoxGroup("Towers")][SerializeField] private TowerLevelsConfig towersLevelsConfig_Magic;

    [BoxGroup("Enemies")][SerializeField] private List<AssetReference> enemyAssets;

    private void Awake()
    {
        Ins = this;
    }

    public void Init()
    {
        projectiles = new List<Projectile>();
        enemiesInstantiated = new List<Tuple<EnemyType, Enemy>>();
    }

    public async UniTask<Tower> GetTowerAssetByType(TowerType _towerType)
    {
        switch (_towerType)
        {
            case TowerType.Archer:
            default:
                var tArcher = await LoadPrefabAsync(towersLevelsConfig_Archer.towerLevels[(int)TowerLvl.LVL_1]);
                return tArcher.GetComponent<Tower>();
            
            case TowerType.Magic:
                var tMagic = await LoadPrefabAsync(towersLevelsConfig_Magic.towerLevels[(int)TowerLvl.LVL_1]);
                return tMagic.GetComponent<Tower>();
        }
    }
    
    public async UniTask<Sprite> LoadSpriteAsync(AssetReferenceSprite spriteRef)
    {
        AsyncOperationHandle<Sprite> handle = spriteRef.LoadAssetAsync<Sprite>();
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            return handle.Result;
        }
        else
        {
            return null;
        }
    }

    public async UniTask<GameObject> LoadPrefabAsync(AssetReference prefabRef)
    {
        AsyncOperationHandle<GameObject> handle = prefabRef.InstantiateAsync();
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            return handle.Result;
        }
        else
        {
            return null;
        }
    }
    
    // * =====================================================================================================================================
    // * PROJECTILES

    private List<Tuple<EnemyType, Enemy>> enemiesInstantiated;
    
    public async UniTask<Enemy> GetEnemy(EnemyType _enemyType)
    {
        foreach (var enemy in enemiesInstantiated)
        {
            if (enemy.Item1 == _enemyType && !enemy.Item2.IsActive)
            {
                return enemy.Item2;
            }
        }

        var obj = await LoadPrefabAsync(enemyAssets[(int)_enemyType]);
        var e = obj.GetComponent<Enemy>();
        enemiesInstantiated.Add(new Tuple<EnemyType, Enemy>(_enemyType, e));
        
        return e;
    }

    // * =====================================================================================================================================
    // * PROJECTILES

    private List<Projectile> projectiles;
    
    public async UniTask<Projectile> GetProjectile(ProjectileType _type)
    {
        foreach (var projectile in projectiles)
        {
            if (!projectile.IsActive)
            {
                return projectile;
            }
        }

        var obj = await LoadPrefabAsync(projectileMagic);
        var p = obj.GetComponent<Projectile>();
        projectiles.Add(p);
        
        return p;
    }
}