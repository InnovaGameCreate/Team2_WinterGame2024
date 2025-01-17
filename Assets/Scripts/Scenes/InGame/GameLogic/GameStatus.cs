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
    public byte PlayerSelectFlask { get; private set; }

    /// <summary>
    /// プレイヤーの選択したアイテム
    /// </summary>
    public byte PlayerSelectItem { get; private set; }
    /// <summary>
    /// プレイヤーの誰が飲むべきかの指定
    /// </summary>
    public Person PlayerSelectPerson { get; private set; }

    public byte EnemySelectFlask { get; private set; }

    public byte EnemySelectItem { get; private set; }

    public Person EnemySelectPerson { get; private set; }


    public bool PlayerUsingSerum { get; private set; }
    public bool EnemyUsingSerum { get; private set; }

    public bool PlayerSleep { get; private set; }
    public bool EnemySleep { get; private set; }

    public byte Round { get; private set; }


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

    public void SetPlayerSelectFlask(byte num) { 
        PlayerSelectFlask = num;
    }

    public void SetEnemySelectFlask(byte num) { 
        EnemySelectFlask = num;
    }

    public void SetPlayerSelectItem(byte num){
        PlayerSelectItem = num;
    }

    public void SetEnemySelectItem(byte num) { 
        EnemySelectItem = num;
    }

    public void SetPlayerSelectPerson(Person person) { 
        PlayerSelectPerson = person;
    }

    public void SetEnemySelectPerson(Person person) {
        EnemySelectPerson = person;
    }

    public void SetPlayerHp(byte hp)
    { 
        _playerHp.Value = hp;
    }

    public void SetEnemyHp(byte hp)
    { 
        _enemyHp.Value = hp; 
    }

    public void SetPlayerUsingSerum(bool set) { 
        PlayerUsingSerum = set;
    }

    public void SetEnemyUsingSerum(bool set) { 
        EnemyUsingSerum = set;
    }

    public void SetPlayerSleep(bool set) { 
        PlayerSleep = set;
    }

    public void SetEnemySleep(bool set) { 
        EnemySleep = set;
    }


    public void SetRound(byte round)
    {
        Round = round;
    }

    public void SetGameState(GameState state)
    {
        _nowGameState.Value = state;
    }

    public void SetScore(int score) { 
        _score.Value = score;
    }


    public void AddScore(int score) { 
        _score.Value += score;
    }

    /// <summary>
    /// フラスコの種類を設定する
    /// </summary>
    /// <param name="index">対象が何番目であるか</param>
    /// <param name="type">設定内容</param>
    public void SetFlaskType(byte index, FlaskType type) {
        _flaskDates[index]= new FlaskDate(_flaskDates[index].tested,type);
    }

    /// <summary>
    /// フラスコを試験したかどうかを設定する
    /// </summary>
    /// <param name="index">対象が何番目であるか</param>
    /// <param name="tested">設定内容</param>
    public void SetFlaskTested(byte index,bool tested) {
        _flaskDates[index] = new FlaskDate(tested, _flaskDates[index].type);
    }













    //＃＃＃＃＃＃＃＃＃＃＃＃＃＃便利な変数たち

    /// <summary>
    /// 残っているフラスコの数を受け取る
    /// </summary>
    /// <returns>フラスコの残っている数</returns>
    public byte FlaskNum() {
        byte num = 0;
        for (byte i = 0; i <= 8;i++) {
            if (FlaskDatesValue[i].type != FlaskType.None) { num++; }
        }
        return num;
    }

    /// <summary>
    /// ランダムに内容の存在するフラスコを選びます
    /// </summary>
    /// <returns></returns>
    public byte RandomMetFlaskNumber() {
        byte pickNum = (byte)UnityEngine.Random.Range(0, FlaskNum());
        byte num = 0;
        for (byte i = 0; i <= 8; i++)
        {
            if (FlaskDatesValue[i].type != FlaskType.None) { pickNum--; }
            if (pickNum < 0) {
                num = i;
                break;
            }
        }
        return num;
    }


    /// <summary>
    /// ランダムにフラスコの位置をシャッフルします
    /// </summary>
    public void FlasksShuffle() {
        FlaskDate[] newArry = FlaskDatesValue.OrderBy(i => Guid.NewGuid()).ToArray();
        for (byte i = 0;i < 9;i++) {
            _flaskDates[i] = newArry[i];
        }
    }

    /// <summary>
    /// フラスコを全て消して試験状態をリセットする
    /// </summary>
    public void FlaskReset() {
        for (byte i = 0; i < 9; i++)
        {
            _flaskDates[i] = new FlaskDate(false,FlaskType.None);
        }
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

    public FlaskDate(bool setTested,FlaskType setFlaskType) { 
        tested = setTested;
        type = setFlaskType;
    }
}
