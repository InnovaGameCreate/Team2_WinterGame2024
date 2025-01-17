using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;

public class PlayerTurnStart : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.PlayerTurnStart)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[�̃^�[���J�n");
        _status.SetGameState(GameState.PlayerSelect);
    }
}


public class PlayerSelect : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.PlayerSelect)
            {
                if (_status.PlayerHpValue <= 0) {
                    Dead(_token);
                }
            }
        }).AddTo(_stateManager.gameObject);

        _commandManager.OnFlaskSelect.Subscribe(x =>
        {
            //�t���X�R��I�������ꍇ
            _status.SetPlayerSelectFlask(x);
            FlaskSelected(_token);
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid Dead(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("HP��0�ł�");
        _status.SetGameState(GameState.GameOver);
    }

    private async UniTaskVoid FlaskSelected(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�t���X�R��I�т܂���");
        _status.SetGameState(GameState.PlayerSelect);
    }
}


public class PlayerSelectedFlask : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.PlayerSelectedFlask)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        if (_status.FlaskDatesValue[_status.PlayerSelectFlask].type == FlaskType.None)
        {
            await UniTask.Delay(100, cancellationToken: token);
            Debug.Log("�����Ƀt���X�R�͑��݂��܂���A�ēx�I��ł�������");
            _status.SetGameState(GameState.PlayerSelect);
        }
        else {
            await UniTask.Delay(100, cancellationToken: token);
            Debug.Log("���݂���t���X�R���I�΂�܂����A���Ɉ��ނ̂����ꂩ�����߂Ă�������");
            _status.SetGameState(GameState.PlayerSelectPerson);
        }
    }
}

public class PlayerSelectPerson : StateBase
{
    public override void AfterInit()
    {
        _commandManager.OnPersonSelect.Subscribe(x =>
        {           
            _status.SetPlayerSelectPerson(x);
            if (x == Person.Player)
            {
                switch (_status.FlaskDatesValue[_status.PlayerSelectFlask].type) 
                {
                    case FlaskType.Water:
                        PPWater(_token);
                        break;
                    case FlaskType.Poison:
                        PPPoison(_token);
                        break;
                    case FlaskType.Random:
                        Debug.LogWarning("�����_���t���X�R��������");
                        break;
                }
            }
            else 
            {
                switch (_status.FlaskDatesValue[_status.PlayerSelectFlask].type)
                {
                    case FlaskType.Water:
                        PEWater(_token);
                        break;
                    case FlaskType.Poison:
                        PEPoison(_token);
                        break;
                    case FlaskType.Random:
                        Debug.LogWarning("�����_���t���X�R��������");
                        break;
                }
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid PPWater(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[�̓v���C���[�ɐ������܂���");
        _status.SetGameState(GameState.PPWater);
    }

    private async UniTaskVoid PPPoison(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[�̓v���C���[�ɐ������܂���");
        _status.SetGameState(GameState.PPPoison);
    }

    private async UniTaskVoid PEWater(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[�͓G�ɐ������܂���");
        _status.SetGameState(GameState.PPWater);
    }

    private async UniTaskVoid PEPoison(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[�͓G�ɐ������܂���");
        _status.SetGameState(GameState.PPPoison);
    }
}

public class PPWater : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.PPWater)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[�������Ő������񂾂̂ŃX�R�AUP");
        _status.AddScore(100);
        _status.SetGameState(GameState.PlayerSelect);
    }
}

public class PPPoison: StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.PPPoison)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[�������œł����񂾂̂Ń_���[�W���󂯂ă^�[�����G�Ɉڂ�܂�");
        _status.SetPlayerHp((byte)(_status.PlayerHpValue -1));
        _status.SetGameState(GameState.EnemyTurnStart);
    }
}

public class PEWater : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.PEWater)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[���G�ɐ������܂��Ă��܂���");
        _status.SetGameState(GameState.EnemySelect);
    }
}

public class PEPoison : StateBase
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.PEPoison)
            {
                StateBehaviour(_token);
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid StateBehaviour(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("�v���C���[���G�ɓł����܂��邱�Ƃɐ�������");
        _status.SetPlayerHp((byte)(_status.PlayerHpValue - 1));
        _status.SetGameState(GameState.EnemyTurnStart);
    }
}