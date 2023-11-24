using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GS_CreateTower : StateBase<GameState>
{
    public GS_CreateTower(GameState _key) : base(_key)
    {
    }
    
    public override async UniTask EnterState()
    {
        Game.BlockInput();
        
        await LevelManager.Ins.AddTower(GetMainClassReference<GameManager>().towerTypeToCreate);
        UI.Ins.towerOptionsUI.HideTowerCreationUI();
        
        Game.ReleaseInput();
    }

    public override UniTask ExitState()
    {
        return default;
    }

    public override void UpdateState()
    {
        
    }
}
