using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�g�����
/// </summary>
enum FlaskType : byte 
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
enum ItemType : byte
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
enum GameState : byte{ 
    Default,
    StartGame,
    StartRound,

    PlayerTurnStart,

    PlayerSelect,

    PlayerUsingItem,
    PlayerUsingAloe,
    PlayerUsingSerum,
    PlayerUsingTests,
    PlayerTestsSelect,
    PlayerUsingSleepingPill,

    PlayerSelectedBottle,
    PlayerSelectDrink,

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

    EnemySelectedBottle,
    EnemySelectDrink,

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
    
    Victry,
}
