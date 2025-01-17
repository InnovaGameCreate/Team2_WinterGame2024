using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    /// <summary>
    /// ���C���[�̑I�������{�g��
    /// </summary>
    public int PlayerSelectFlask { get; }

    /// <summary>
    /// �v���C���[�̑I�������A�C�e��
    /// </summary>
    public int PlayerSelectItem { get; }
    /// <summary>
    /// �v���C���[�̒N�����ނׂ����̎w��
    /// </summary>
    public Person PlayerSelectDrink { get; }

    public int EnemySelectFlask { get; }

    public int EnemySelectItem { get; }

    public Person EnemySelectDrink { get; }


    public bool PlayerUsingSerum { get; }
    public bool EnemyUsingSerum { get; }

    public bool PlayerSleep { get;}
    public bool EnemySleep { get; }




    //####################################
    //###            UniRx             ###
    //####################################

    /// <summary>
    /// �t���X�R�̏��
    /// </summary>
    [SerializeField] private ReactiveCollection<FlaskDate> _flaskDates = new ReactiveCollection<FlaskDate>(new FlaskDate[9]);
    public IObservable<CollectionReplaceEvent<FlaskDate>> OnFlaskdateChange { get { return _flaskDates.ObserveReplace(); } }
    public FlaskDate[] FlaskDatesValue { get { return _flaskDates.ToArray(); } }


    /// <summary>
    /// �v���C���[�̎��A�C�e��
    /// </summary>
    [SerializeField] private ReactiveCollection<ItemType> _playerItems = new ReactiveCollection<ItemType>(new List<ItemType>());
    public IObservable<CollectionReplaceEvent<ItemType>> OnPlayerItemChange { get { return _playerItems.ObserveReplace(); } }
    public List<ItemType> PlayerItemsValue { get { return _playerItems.ToList(); } }

    /// <summary>
    /// �G�̎��A�C�e��
    /// </summary>
    [SerializeField] private ReactiveCollection<ItemType> _enemyItems = new ReactiveCollection<ItemType>(new List<ItemType>());
    public IObservable<CollectionReplaceEvent<ItemType>> OnEnemyItemChange { get { return _enemyItems.ObserveReplace(); } }
    public List<ItemType> EnemyItemsValue { get { return _enemyItems.ToList(); } }

    /// <summary>
    /// �v���C���[�̎c��HP
    /// </summary>
    [SerializeField] private ByteReactiveProperty _playerHp = new ByteReactiveProperty();
    public IObservable<Byte> OnPlayerHpChange { get { return _playerHp; } }
    public byte PlayerHpValue { get { return _playerHp.Value; } }

    /// <summary>
    /// �G�̎c��HP
    /// </summary>
    [SerializeField] private ByteReactiveProperty _enemyHp = new ByteReactiveProperty();
    public IObservable<byte> OnEnemyHpChange { get { return _enemyHp; } }
    public byte EnemyHpValue { get { return _enemyHp.Value; } }

    /// <summary>
    /// �X�R�A
    /// </summary>
    [SerializeField]private IntReactiveProperty _score = new IntReactiveProperty();
    public IObservable<int> OnScoreChange { get { return _score; } }
    public int ScoreValue { get { return _score.Value; } }

    /// <summary>
    /// �Q�[���̐i�s���
    /// </summary>
    [SerializeField]private ReactiveProperty<GameState> _nowGameState = new ReactiveProperty<GameState>();
    public IObservable<GameState> OnGameStateChange { get { return _nowGameState; } }
    public GameState NowGameStateValue { get { return _nowGameState.Value; } }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct FlaskDate 
{
    /// <summary>
    /// ������Ō�������Ă��邩�ǂ���
    /// </summary>
    public bool tested;
    /// <summary>
    /// ���
    /// </summary>
    public FlaskType type;   
}
