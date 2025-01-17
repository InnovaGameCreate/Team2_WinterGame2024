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
    //State���甭�s�����C�x���g
    //###############

    /// <summary>
    /// �t���X�R�̒��g�����ނƂ���
    /// </summary>
    private Subject<Unit> _flaskDrinkSubject = new Subject<Unit>();
    public IObservable<Unit> OnFlaskDrink
    {
        get { return _flaskDrinkSubject; }
    }

    /// <summary>
    /// �ł����ݏI�������ɔ��s
    /// </summary>
    private Subject<Unit> _poisonDrinkSubject = new Subject<Unit>();
    public IObservable<Unit> OnPoisonDrink
    {
        get { return _poisonDrinkSubject; }
    }

    /// <summary>
    /// �����_�������ݏI�������ɔ��s
    /// </summary>
    private Subject<byte> _randomDrinkSubject = new Subject<byte>();
    public IObservable<byte> OnRandomDrink
    {
        get { return _randomDrinkSubject; }
    }







    /// <summary>
    /// �t���X�R�����񂾎��ɔ��s
    /// </summary>
    public void OnDrinkFlaskEvent() { 
        
    }






    // Start is called before the first frame update
    void Start()
    {       
        token = new CancellationTokenSource().Token;

        //�����ŃX�N���v�g�����







        _gameStatus.SetGameState(GameState.StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
