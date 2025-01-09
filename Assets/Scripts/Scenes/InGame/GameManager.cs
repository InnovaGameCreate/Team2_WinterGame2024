using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public int round = 0;   // 3���E���h�܂�
    public int roop = 0;    // ���[�v�A�X�R�A�v�Z�p

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        while (round < 4)
        {
            while(IsExistFlask())
            {
                PlayerTurn();
                if (!IsExistFlask()) break;
                EnemyTurn();
            }
        }
    }

    // �Տ�Ƀt���X�R���c���Ă��邩���ׂ�
    bool IsExistFlask()
    {
        bool exist = true;
        for(int i = 0; i < 8; i++) {
            if (LifeManager.flaskStatus[i] != 5)
            {
                exist = false; 
                break;
            }
        }
        return exist;
    }

    void PlayerTurn()
    {
        isPlayerTurn = true;
        Debug.Log("�v���C���[�̃^�[��");
    }

    void EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("�G�̃^�[��");
    }
}
