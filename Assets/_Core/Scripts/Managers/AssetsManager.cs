using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

public class AssetsManager : MonoBehaviour
{
    public static AssetsManager Ins;
    
    public AssetReferenceSprite spriteReference;

    [BoxGroup("Projectiles")] public AssetReference projectileArrow;
    [BoxGroup("Projectiles")] public AssetReference projectileMagic;
    
    [BoxGroup("Towers")] public TowerLevelsConfig towersLevelsConfig_Archer;
    [BoxGroup("Towers")] public TowerLevelsConfig towersLevelsConfig_Magic;

    private void Awake()
    {
        Ins = this;
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

    public List<Projectile> projectiles;
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