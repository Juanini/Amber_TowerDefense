using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GS_Win : StateBase<GameState>
{

    public GS_Win(GameState _key) : base(_key)
    {
    }

    public override UniTask EnterState()
    {
        return default;
    }

    public override UniTask ExitState()
    {
        return default;
    }

    public override void UpdateState()
    {
        
    }
}
