using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using System.Threading;


public class StartGame : StateBase 
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.StartGame) {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token) {
        await UniTask.Delay(100, cancellationToken: token);
        _status.SetRound(1);
        _status.SetGameState(GameState.StartRound);
    }
}

public class RoundStart : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.StartRound)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        _status.SetRound(1);
        _status.SetGameState(GameState.PlayerTurnStart);
    }
}

public class GameOver : StateBase
{
    //シーンローディング
}

public class GameClear : StateBase
{
    //シーンローディング
}



