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
        Debug.Log("�Q�[���J�n���܂���");
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
        Debug.Log(_status.Round + "���E���h�J�n���܂��� ");
        _status.SetGameState(GameState.StartRoop);
    }
}

public class RoundRoop : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.StartRoop)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("���[�v�J�n ");
        ///////////////////////////////////////�{�g������
        byte waterNum = (byte)UnityEngine.Random.Range(1,5);
        byte poisonNum = (byte)UnityEngine.Random.Range(1, 5);
        //bool randomFlask = ((byte)UnityEngine.Random.Range(0, 4) == 0);
        bool randomFlask = false;//�����_�������O�Ȃ̂ňꎟ�I�ɂ킩�Ȃ��悤�ɂ��Ă���

        _status.FlaskReset();//�t���X�R�����Z�b�g

        for (byte i = 0; i < 9;i++) {
            if (waterNum > 0) {
                waterNum--;
                _status.SetFlaskType(i, FlaskType.Water);
            } else if (poisonNum > 0) {
                poisonNum--;
                _status.SetFlaskType(i, FlaskType.Poison);
            } else if (randomFlask) { 
                randomFlask = false;
                _status.SetFlaskType(i, FlaskType.Random);
            }
        }
        _status.FlasksShuffle();
        Debug.LogWarning("�����_����ǉ�����");
        _status.SetGameState(GameState.PlayerTurnStart);
    }
}

public class GameOver : StateBase
{
   //�V�[�����[�f�B���O����
}

public class GameClear : StateBase
{
    //�V�[�����[�f�B���O
}



