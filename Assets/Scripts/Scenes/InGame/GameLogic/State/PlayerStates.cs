using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerStates : StateBase
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
