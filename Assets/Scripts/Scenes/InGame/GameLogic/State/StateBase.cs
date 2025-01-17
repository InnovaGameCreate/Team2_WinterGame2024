using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StateBase
{
    //�����F�N���X�̓|�C���^

    protected GameStateManager _stateManager;
    protected GameStatus _status;
    protected GameCommandManager _commandManager;

    /// <summary>
    /// �J�n���ɃA�N�Z�X
    /// </summary>
    /// <param name="gameStateManager">�Q�[���X�e�[�g�}�l�[�W���[</param>
    /// <param name="gameStatus">�Q�[���̃X�e�[�^�X</param>
    /// <param name="gameCommandManager">�Q�[���̃R�}���h�}�l�[�W���[</param>
    public void Init(GameStateManager gameStateManager,GameStatus gameStatus,GameCommandManager gameCommandManager) { 
        _stateManager = gameStateManager;
        _status = gameStatus;
        _commandManager = gameCommandManager;
    }

    /// <summary>
    /// Init�ŏ�������o�^������ɓ���
    /// </summary>
    public virtual void AfterInit() { 
        Debug.LogWarning("State�̓��e���S������܂���");
    }
}
