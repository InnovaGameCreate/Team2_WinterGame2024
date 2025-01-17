using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerStates : StateBase
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
