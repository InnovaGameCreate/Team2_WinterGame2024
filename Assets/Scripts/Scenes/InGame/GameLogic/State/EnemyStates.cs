using System.Collections;
using UniRx;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

public class EnemyStates : StateBase
{
    /// <summary>
    /// Initで初期情報を登録した後に動く
    /// </summary>
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {

        }).AddTo(_stateManager.gameObject);
    }
}
