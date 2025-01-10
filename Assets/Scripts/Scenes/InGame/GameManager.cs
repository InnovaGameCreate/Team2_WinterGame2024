using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public int round = 1;   // 3ラウンドまで
    public int roop = 0;    // ループ、スコア計算用
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject timerText;
    public Text countdownText; // カウントダウン用
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

                if (!IsExistFlask())
                {
                    CameraChanger.CameraChange();
                    break;
                }

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

        // 3ラウンド終了時の動作書く
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

        timerText.SetActive(true);
        int remainingTime = 10; // 10秒カウントダウン

        while (remainingTime > 0)
        {
            if (!isPlayerTurn)
            {
                Debug.Log("プレイヤーのターン終了");
                timerText.SetActive(false);
                yield break; // 即時終了
            }
            countdownText.text = remainingTime.ToString(); // UIに表示
            yield return new WaitForSeconds(1f); // 1秒待機
            remainingTime--;
        }

        countdownText.text = "TimeUp"; // 0秒でメッセージを表示
        Debug.Log("時間切れ");
        timerText.SetActive(false);
    }

    IEnumerator EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("敵のターン");
        CameraChanger.CameraChange();
        // 敵のアクションを書く
        yield return new WaitForSeconds(5.0f);   // 5秒待機
    }
}
