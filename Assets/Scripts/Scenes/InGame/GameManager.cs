using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public int round = 1;   // 3ラウンドまで
    public int roop = 0;    // ループ、スコア計算用
    [SerializeField] private GameObject gameStart;

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        gameStart.SetActive(true);
        yield return new WaitForSeconds(3.0f);  // 3秒待機
        gameStart.SetActive(false);

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
        CameraChanger.CameraChange();

        float elapsedTime = 0f;
        float waitTime = 10.0f;

        while (elapsedTime < waitTime)
        {
            if (!isPlayerTurn)
            {
                yield break; // 即時終了
            }

            yield return null; // 1フレーム待機
            elapsedTime += Time.deltaTime;
        }
    }

    IEnumerator EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("敵のターン");
        CameraChanger.CameraChange();
        yield return new WaitForSeconds(5.0f);   // 5秒待機
    }
}
