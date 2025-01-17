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
        Debug.Log("�Q�[���J�n");
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
        ////////////////////////////////�����Ƀt���X�R�̐ݒu���s��
        Debug.LogWarning("�����_���t���X�R��������");



        Debug.Log(_status.Round + "���E���h�J�n ");
        _status.SetGameState(GameState.PlayerTurnStart);
    }
}

public class GameOver : StateBase
{
    //�V�[�����[�f�B���O
}

public class GameClear : StateBase
{
    //�V�[�����[�f�B���O
}



