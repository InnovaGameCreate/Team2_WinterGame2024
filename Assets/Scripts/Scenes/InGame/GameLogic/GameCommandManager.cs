using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UniRx;
using UnityEngine;

public class GameCommandManager : MonoBehaviour
{
    /// <summary>
    /// �L�[�{�[�h�R�}���h���󂯕t���邩
    /// </summary>
    [SerializeField] private bool _keyComand;

    /// <summary>
    /// �f�o�b�O���O��\�����邩�ǂ���
    /// </summary>
    [SerializeField] private bool _debugMode;




    //#####
    //�{�g���N���b�N
    //#####
    private Subject<byte> _flaskSelectSubject = new Subject<byte>();
    public IObservable<byte> OnFlaskSelect
    {
        get { return _flaskSelectSubject; }
    }

    //#####
    //�A�C�e���N���b�N
    //#####
    private Subject<byte> _itemSelectSubject = new Subject<byte>();
    public IObservable<byte> OnItemSelect
    {
        get { return _itemSelectSubject; }
    }


    //#####
    //���ރN���b�N
    //#####
    private Subject<Person> _personSelectSubject = new Subject<Person>();
    public IObservable<Person> OnPersonSelect
    {
        get { return _personSelectSubject; }
    }



    //#####
    //�j���N���b�N
    //#####
    private Subject<Unit> _revocationSubject = new Subject<Unit>();
    public IObservable<Unit> Onrevocation
    {
        get { return _revocationSubject; }
    }

    /// <summary>
    /// �t���X�R��I��
    /// </summary>
    /// <param name="num">�t���X�R�̔ԍ�</param>
    public void FlaskSelect(byte num) {
        _flaskSelectSubject.OnNext(num);
#if UNITY_EDITOR
        if(_debugMode)Debug.Log("�t���X�R�I��:" + num);
#endif
    }

    /// <summary>
    /// �A�C�e����I��
    /// </summary>
    /// <param name="num">�A�C�e���̔ԍ�</param>
    public void ItemSelect(byte num) {
        _itemSelectSubject.OnNext(num);
#if UNITY_EDITOR
        if (_debugMode) Debug.Log("�A�C�e���I��:" + num);
#endif
    }

    /// <summary>
    /// �����I��
    /// </summary>
    /// <param name="person">����</param>
    public void PersonSelect(Person person) {
        _personSelectSubject.OnNext(person);
#if UNITY_EDITOR
        if (_debugMode) Debug.Log("����I��:" + person);
#endif
    }

    /// <summary>
    /// �j�����܂�
    /// </summary>
    public void Revocation() {
        _revocationSubject.OnNext(Unit.Default);
#if UNITY_EDITOR
        if (_debugMode) Debug.Log("�j���I��");
#endif
    }



    void Update()
    {
#if UNITY_EDITOR
        if (_keyComand) {
            //�t���X�R�̑I��
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

            //�A�C�e���̑I��
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


            //����I��
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PersonSelect(Person.Enemy);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PersonSelect(Person.Player);
            }

            //�j���I��
            if (Input.GetKeyDown(KeyCode.D))
            {
                Revocation();
            }

        }
#endif
    }


}
