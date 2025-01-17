using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SoundPresenter : MonoBehaviour
{
    [SerializeField] private GameStatus _gameStatus;
    [SerializeField] private SoundView _soundView;
    [SerializeField] private GameStateManager _gameStateManager;

    private byte _lastPlayerHp = byte.MaxValue;
    private byte _lastEnemyHp = byte.MaxValue;

    void Start()
    {
        _gameStatus.OnGameStateChange.Subscribe(x => {
            switch (x)
            {
                default:
                    break;
                case GameState.StartRound:
                    _soundView.RoundChange();
                    break;
                case GameState.PlayerUsingAloe:
                case GameState.EnemyUsingAloe:
                    _soundView.UseAloe();
                    break;
                case GameState.PlayerUsingSerum:
                    case GameState.EnemyUsingSerum:
                    _soundView.UseSerum();
                    break;
                case GameState.PlayerUsingSleepingPill:
                case GameState.EnemyUsingSleepingPill:
                    _soundView.UseSleepingPill();
                    break;
                case GameState.GameClear:
                    _soundView.Victory();
                    break;
            }
        }).AddTo(this);
        _gameStatus.OnPlayerHpChange.Skip(1).Subscribe(x => {
            if (x < _lastPlayerHp)
            {
                _soundView.DecreaseHp();
            }
            _lastPlayerHp = (byte)x;
        }).AddTo(this);

        _gameStatus.OnEnemyHpChange.Skip(1).Subscribe(x => {
            if (x < _lastEnemyHp)
            {
                _soundView.DecreaseHp();
            }
            _lastEnemyHp = (byte)x;
        }).AddTo(this);
        

        //フラスコ系統のイベントをサブスクライブ        
        _gameStateManager.OnFlaskDrink.Subscribe(x => 
        {
            _soundView.FlaskDrink();
        }).AddTo(this);
        _gameStateManager.OnPoisonDrink.Subscribe(x => 
        {
            _soundView.PoisonDrink();
        }).AddTo(this);
        _gameStateManager.OnRandomDrink.Subscribe(x => 
        { 
            _soundView.RandomDrink();
        }).AddTo(this);


    }
}
