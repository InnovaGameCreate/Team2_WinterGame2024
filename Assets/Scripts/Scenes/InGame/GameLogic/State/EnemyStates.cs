using System.Collections;
using UniRx;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using TMPro.EditorUtilities;

public class EnemyTurnStart : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.EnemyTurnStart)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("敵のターン開始");
        _status.SetGameState(GameState.EnemySelect);
    }
}

public class EnemySelect : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (_status.EnemyHpValue <= 0) {
                Debug.Log("敵はHPが0だ！");
                if (_status.Round >= 3) { 
                
                }



            }





            if (x == GameState.EnemySelect)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("プレイヤーのターン開始");
        _status.SetGameState(GameState.EnemySelect);
    }
}
