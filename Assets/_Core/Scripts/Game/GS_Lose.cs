using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GS_Lose : StateBase<GameState>
{
    public GS_Lose(GameState _key) : base(_key)
    {
    }

    public override async UniTask EnterState()
    {
        await UI.Ins.nav.ShowPopup<LoseView>();
    }

    public override UniTask ExitState()
    {
        return default;
    }

    public override void UpdateState()
    {
        
    }
}
