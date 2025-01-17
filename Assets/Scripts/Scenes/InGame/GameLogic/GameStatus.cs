using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    /// <summary>
    /// レイヤーの選択したボトル
    /// </summary>
    public int PlayerSelectFlask { get; }

    /// <summary>
    /// プレイヤーの選択したアイテム
    /// </summary>
    public int PlayerSelectItem { get; }
    /// <summary>
    /// プレイヤーの誰が飲むべきかの指定
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
    /// フラスコの情報
    /// </summary>
    [SerializeField] private ReactiveCollection<FlaskDate> _flaskDates = new ReactiveCollection<FlaskDate>(new FlaskDate[9]);
    public IObservable<CollectionReplaceEvent<FlaskDate>> OnFlaskdateChange { get { return _flaskDates.ObserveReplace(); } }
    public FlaskDate[] FlaskDatesValue { get { return _flaskDates.ToArray(); } }


    /// <summary>
    /// プレイヤーの持つアイテム
    /// </summary>
    [SerializeField] private ReactiveCollection<ItemType> _playerItems = new ReactiveCollection<ItemType>(new List<ItemType>());
    public IObservable<CollectionReplaceEvent<ItemType>> OnPlayerItemChange { get { return _playerItems.ObserveReplace(); } }
    public List<ItemType> PlayerItemsValue { get { return _playerItems.ToList(); } }

    /// <summary>
    /// 敵の持つアイテム
    /// </summary>
    [SerializeField] private ReactiveCollection<ItemType> _enemyItems = new ReactiveCollection<ItemType>(new List<ItemType>());
    public IObservable<CollectionReplaceEvent<ItemType>> OnEnemyItemChange { get { return _enemyItems.ObserveReplace(); } }
    public List<ItemType> EnemyItemsValue { get { return _enemyItems.ToList(); } }

    /// <summary>
    /// プレイヤーの残りHP
    /// </summary>
    [SerializeField] private ByteReactiveProperty _playerHp = new ByteReactiveProperty();
    public IObservable<Byte> OnPlayerHpChange { get { return _playerHp; } }
    public byte PlayerHpValue { get { return _playerHp.Value; } }

    /// <summary>
    /// 敵の残りHP
    /// </summary>
    [SerializeField] private ByteReactiveProperty _enemyHp = new ByteReactiveProperty();
    public IObservable<byte> OnEnemyHpChange { get { return _enemyHp; } }
    public byte EnemyHpValue { get { return _enemyHp.Value; } }

    /// <summary>
    /// スコア
    /// </summary>
    [SerializeField]private IntReactiveProperty _score = new IntReactiveProperty();
    public IObservable<int> OnScoreChange { get { return _score; } }
    public int ScoreValue { get { return _score.Value; } }

    /// <summary>
    /// ゲームの進行状態
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
    /// 試験薬で検査されているかどうか
    /// </summary>
    public bool tested;
    /// <summary>
    /// 種類
    /// </summary>
    public FlaskType type;   
}
