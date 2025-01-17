using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class StartGame : StateBase 
{
    public override void AfterInit()
    {
        _status.OnGameStateChange.Subscribe(x =>
        {
            if (x == GameState.StartGame) { 
            
            
            }
        }).AddTo(_stateManager.gameObject);
    }
}

public class RoundStart : StateBase
{

}

public class GameOver : StateBase
{

}

public class GameClear : StateBase
{

}



