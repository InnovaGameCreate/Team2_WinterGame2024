using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StateBase
{
    //メモ：クラスはポインタ

    protected GameStateManager _stateManager;
    protected GameStatus _status;
    protected GameCommandManager _commandManager;

    /// <summary>
    /// 開始時にアクセス
    /// </summary>
    /// <param name="gameStateManager">ゲームステートマネージャー</param>
    /// <param name="gameStatus">ゲームのステータス</param>
    /// <param name="gameCommandManager">ゲームのコマンドマネージャー</param>
    public void Init(GameStateManager gameStateManager,GameStatus gameStatus,GameCommandManager gameCommandManager) { 
        _stateManager = gameStateManager;
        _status = gameStatus;
        _commandManager = gameCommandManager;
    }

    /// <summary>
    /// Initで初期情報を登録した後に動く
    /// </summary>
    public virtual void AfterInit() { 
        Debug.LogWarning("Stateの内容が全くありません");
    }
}
