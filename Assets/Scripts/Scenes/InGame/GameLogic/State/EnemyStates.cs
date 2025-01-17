using System.Collections;
using UniRx;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

public class EnemyStates : StateBase
{
    /// <summary>
    /// Init‚Å‰Šúî•ñ‚ğ“o˜^‚µ‚½Œã‚É“®‚­
    /// </summary>
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {

        }).AddTo(_stateManager.gameObject);
    }
}
