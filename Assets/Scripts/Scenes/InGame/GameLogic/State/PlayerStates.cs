using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerStates : StateBase
{
    /// <summary>
    /// Init�ŏ�������o�^������ɓ���
    /// </summary>
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {

        }).AddTo(_stateManager.gameObject);
    }
}
