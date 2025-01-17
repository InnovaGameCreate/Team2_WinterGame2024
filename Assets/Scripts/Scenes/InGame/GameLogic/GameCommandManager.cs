using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UniRx;
using UnityEngine;

public class GameCommandManager : MonoBehaviour
{
    /// <summary>
    /// キーボードコマンドを受け付けるか
    /// </summary>
    [SerializeField] private bool _keyComand;

    /// <summary>
    /// デバッグログを表示するかどうか
    /// </summary>
    [SerializeField] private bool _debugMode;




    //#####
    //ボトルクリック
    //#####
    private Subject<byte> _flaskSelectSubject = new Subject<byte>();
    public IObservable<byte> OnFlaskSelect
    {
        get { return _flaskSelectSubject; }
    }

    //#####
    //アイテムクリック
    //#####
    private Subject<byte> _itemSelectSubject = new Subject<byte>();
    public IObservable<byte> OnItemSelect
    {
        get { return _itemSelectSubject; }
    }


    //#####
    //飲むクリック
    //#####
    private Subject<Person> _personSelectSubject = new Subject<Person>();
    public IObservable<Person> OnPersonSelect
    {
        get { return _personSelectSubject; }
    }



    //#####
    //破棄クリック
    //#####
    private Subject<Unit> _revocationSubject = new Subject<Unit>();
    public IObservable<Unit> Onrevocation
    {
        get { return _revocationSubject; }
    }

    /// <summary>
    /// フラスコを選ぶ
    /// </summary>
    /// <param name="num">フラスコの番号</param>
    public void FlaskSelect(byte num) {
        _flaskSelectSubject.OnNext(num);
#if UNITY_EDITOR
        if(_debugMode)Debug.Log("フラスコ選択:" + num);
#endif
    }

    /// <summary>
    /// アイテムを選ぶ
    /// </summary>
    /// <param name="num">アイテムの番号</param>
    public void ItemSelect(byte num) {
        _itemSelectSubject.OnNext(num);
#if UNITY_EDITOR
        if (_debugMode) Debug.Log("アイテム選択:" + num);
#endif
    }

    /// <summary>
    /// 相手を選ぶ
    /// </summary>
    /// <param name="person">相手</param>
    public void PersonSelect(Person person) {
        _personSelectSubject.OnNext(person);
#if UNITY_EDITOR
        if (_debugMode) Debug.Log("相手選択:" + person);
#endif
    }

    /// <summary>
    /// 破棄します
    /// </summary>
    public void Revocation() {
        _revocationSubject.OnNext(Unit.Default);
#if UNITY_EDITOR
        if (_debugMode) Debug.Log("破棄選択");
#endif
    }



    void Update()
    {
#if UNITY_EDITOR
        if (_keyComand) {
            //フラスコの選択
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                FlaskSelect(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FlaskSelect(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FlaskSelect(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                FlaskSelect(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                FlaskSelect(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                FlaskSelect(5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                FlaskSelect(6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                FlaskSelect(7);
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                FlaskSelect(8);
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                FlaskSelect(9);
            }

            //アイテムの選択
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                ItemSelect(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                ItemSelect(1);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                ItemSelect(2);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                ItemSelect(3);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                ItemSelect(4);
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                ItemSelect(5);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                ItemSelect(6);
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                ItemSelect(7);
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                ItemSelect(8);
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                ItemSelect(9);
            }


            //相手選択
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PersonSelect(Person.Enemy);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PersonSelect(Person.Player);
            }

            //破棄選択
            if (Input.GetKeyDown(KeyCode.D))
            {
                Revocation();
            }

        }
#endif
    }


}
