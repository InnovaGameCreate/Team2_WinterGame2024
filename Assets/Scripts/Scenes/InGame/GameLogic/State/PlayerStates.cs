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
        Debug.Log("プレイヤーのターン開始");
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
            //フラスコを選択した場合
            _status.SetPlayerSelectFlask(x);
            FlaskSelected(_token);
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid Dead(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("HPが0です");
        _status.SetGameState(GameState.GameOver);
    }

    private async UniTaskVoid FlaskSelected(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("フラスコを選びました");
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
            Debug.Log("そこにフラスコは存在しません、再度選んでください");
            _status.SetGameState(GameState.PlayerSelect);
        }
        else {
            await UniTask.Delay(100, cancellationToken: token);
            Debug.Log("存在するフラスコが選ばれました、次に飲むのがだれかを決めてください");
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
                        Debug.LogWarning("ランダムフラスコ実装せよ");
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
                        Debug.LogWarning("ランダムフラスコ実装せよ");
                        break;
                }
            }
        }).AddTo(_stateManager.gameObject);
    }

    private async UniTaskVoid PPWater(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("プレイヤーはプレイヤーに水を飲ませた");
        _status.SetGameState(GameState.PPWater);
    }

    private async UniTaskVoid PPPoison(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("プレイヤーはプレイヤーに水を飲ませた");
        _status.SetGameState(GameState.PPPoison);
    }

    private async UniTaskVoid PEWater(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("プレイヤーは敵に水を飲ませた");
        _status.SetGameState(GameState.PPWater);
    }

    private async UniTaskVoid PEPoison(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        Debug.Log("プレイヤーは敵に水を飲ませた");
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
        Debug.Log("プレイヤーが自分で水を飲んだのでスコアUP");
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
        Debug.Log("プレイヤーが自分で毒を飲んだのでダメージを受けてターンが敵に移ります");
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
        Debug.Log("プレイヤーが敵に水を飲ませてしまった");
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
        Debug.Log("プレイヤーが敵に毒を飲ませることに成功した");
        _status.SetPlayerHp((byte)(_status.PlayerHpValue - 1));
        _status.SetGameState(GameState.EnemyTurnStart);
    }
}