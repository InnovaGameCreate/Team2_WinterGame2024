using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public int round = 0;   // 3ラウンドまで
    public int roop = 0;    // ループ、スコア計算用

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

    // 盤上にフラスコが残っているか調べる
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
        Debug.Log("プレイヤーのターン");
    }

    void EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("敵のターン");
    }
}
