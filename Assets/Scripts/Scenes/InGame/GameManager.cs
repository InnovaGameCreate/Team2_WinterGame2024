using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public int round = 1;   // 3ラウンドまで
    public int roop = 0;    // ループ、スコア計算用

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        while (round <= 3)  // 1～3ラウンド
        {
            while (IsExistFlask())
            {
                yield return StartCoroutine(PlayerTurn());

                if (!IsExistFlask()) break;

                yield return StartCoroutine(EnemyTurn());
                roop++;
            }

            for (int i = 0; i < 8; i++)
            {
                LifeManager.flaskStatus[i] = Random.Range(0, LifeManager.itemNumber);
                LifeManager.flaskArray[i].SetActive(true);
            }
            Debug.Log($"ラウンド {round} 終了");
            round++; // ラウンドを進める
        }
    }

    // 盤上にフラスコが残っているか調べる
    bool IsExistFlask()
    {
        for (int i = 0; i < 8; i++)
        {
            if (LifeManager.flaskStatus[i] != 5)
            {
                return true; // フラスコが存在する
            }
        }
        return false;
    }

    IEnumerator PlayerTurn()
    {
        isPlayerTurn = true;
        Debug.Log("プレイヤーのターン");
        yield return new WaitForSeconds(3.0f);   // 3秒待機
    }

    IEnumerator EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("敵のターン");
        yield return new WaitForSeconds(3.0f);   // 3秒待機
    }
}
