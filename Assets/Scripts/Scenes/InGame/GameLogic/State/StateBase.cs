using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;

public class StateBase
{
    //�����F�N���X�̓|�C���^

    protected GameStateManager _stateManager;
    protected GameStatus _status;
    protected GameCommandManager _commandManager;
    protected CancellationToken _token;

    /// <summary>
    /// �J�n���ɃA�N�Z�X
    /// </summary>
    /// <param name="gameStateManager">�Q�[���X�e�[�g�}�l�[�W���[</param>
    /// <param name="gameStatus">�Q�[���̃X�e�[�^�X</param>
    /// <param name="gameCommandManager">�Q�[���̃R�}���h�}�l�[�W���[</param>
    public void Init(GameStateManager gameStateManager,GameStatus gameStatus,GameCommandManager gameCommandManager,CancellationToken token) { 
        _stateManager = gameStateManager;
        _status = gameStatus;
        _commandManager = gameCommandManager;
        _token = token;
    }

    /// <summary>
    /// Init�ŏ�������o�^������ɓ���
    /// </summary>
    public virtual void AfterInit(){ 
        Debug.LogWarning("State�̓��e���S������܂���");
    }
}
