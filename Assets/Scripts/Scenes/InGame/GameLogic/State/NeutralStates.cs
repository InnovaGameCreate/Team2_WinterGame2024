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
        Debug.Log("ゲーム開始");
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
        ////////////////////////////////ここにフラスコの設置を行う
        Debug.LogWarning("ランダムフラスコ実装せよ");



        Debug.Log(_status.Round + "ラウンド開始 ");
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



