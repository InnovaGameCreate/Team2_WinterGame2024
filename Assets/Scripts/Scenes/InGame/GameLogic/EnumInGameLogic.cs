using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Person : byte { 
    Player,
    Enemy,
}

/// <summary>
/// �{�g�����
/// </summary>
public enum FlaskType : byte 
{ 
    Default,
    Water,
    Poison,
    Random,
    None,
}

/// <summary>
/// �A�C�e�����
/// </summary>
public enum ItemType : byte
{ 
    Default,
    /// <summary>
    /// �A���G
    /// </summary>
    Aloe,
    /// <summary>
    /// ����
    /// </summary>
    Serum,
    /// <summary>
    /// ������
    /// </summary>
    Tests,
    /// <summary>
    /// ������
    /// </summary>
    SleepingPill,
    /// <summary>
    /// ���݂��Ȃ�
    /// </summary>
    None,
}

/// <summary>
/// �Q�[���̐i�s��
/// </summary>
public enum GameState : byte{ 
    Default,
    StartGame,
    StartRound,
    StartRoop,

    PlayerTurnStart,

    PlayerSelect,

    PlayerUsingItem,
    PlayerUsingAloe,
    PlayerUsingSerum,
    PlayerUsingTests,
    PlayerTestsSelect,
    PlayerUsingSleepingPill,

    PlayerSelectedFlask,
    PlayerSelectPerson,

    //PP=PlayertoPlayer PE=PlayertoEnemy EE=EnemytoEnemy EP=EnemytoPlayer
    PPWater,
    PPPoison,
    PPCopy,
    PPHeavyDamage,
    PPBlind,
    PPShuffle,
    PPReversal,
    PPRecovery,

    PEWater,
    PEPoison,
    PECopy,
    PEHeavyDamage,
    PEBlind,
    PEShuffle,
    PEReversal,
    PERecovery,

    PlayerTurnEnd,

    PlayerDead,
    PlayerRevocation,
    //PlayerSurrender,

    EnemyTurnStart,
    EnemySelect,

    EnemyUsingItem,
    EnemyUsingAloe,
    EnemyUsingSerum,
    EnemyUsingTests,
    EnemyTestsSelect,
    EnemyUsingSleepingPill,

    EnemySelectedFlask,
    //EnemySelectDrink,

    //PP=PlayertoPlayer PE=PlayertoEnemy EE=EnemytoEnemy EP=EnemytoPlayer
    EEWater,
    EEPoison,
    EECopy,
    EEHeavyDamage,
    EEBlind,
    EEShuffle,
    EEReversal,
    EERecovery,

    EPWater,
    EPPoison,
    EPCopy,
    EPHeavyDamage,
    EPBlind,
    EPShuffle,
    EPReversal,
    EPRecovery,

    EnemyTurnEnd,

    EnemyDead,
    
    GameOver,
    GameClear,
}
