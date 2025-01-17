using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

public class GameStateManager : MonoBehaviour 
{
    [SerializeField]private GameStatus _gameStatus;
    [SerializeField]private GameCommandManager _gameCommandManager;

    private CancellationToken token;

    //###############
    //Stateから発行されるイベント
    //###############

    /// <summary>
    /// フラスコの中身を飲むときに
    /// </summary>
    private Subject<Unit> _flaskDrinkSubject = new Subject<Unit>();
    public IObservable<Unit> OnFlaskDrink
    {
        get { return _flaskDrinkSubject; }
    }

    /// <summary>
    /// 毒を飲み終えた時に発行
    /// </summary>
    private Subject<Unit> _poisonDrinkSubject = new Subject<Unit>();
    public IObservable<Unit> OnPoisonDrink
    {
        get { return _poisonDrinkSubject; }
    }

    /// <summary>
    /// ランダムを飲み終えた時に発行
    /// </summary>
    private Subject<byte> _randomDrinkSubject = new Subject<byte>();
    public IObservable<byte> OnRandomDrink
    {
        get { return _randomDrinkSubject; }
    }







    /// <summary>
    /// フラスコを飲んだ時に発行
    /// </summary>
    public void OnDrinkFlaskEvent() { 
        
    }






    // Start is called before the first frame update
    void Start()
    {       
        token = new CancellationTokenSource().Token;

        //ここでスクリプトを作る







        _gameStatus.SetGameState(GameState.StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
