using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = false;
    public static bool isEnemyTurn = false;
    public static int round = 1;   // 3ラウンドまで
    public static int roop = 0;    // ループ、スコア計算用
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject timerText;
    public Text countdownText; // カウントダウン用
    public static GameObject infoObject; // 進行通知用
    public static Text infoText; // 進行通知用
    public static int isWin = 0;   // 勝利判定用(0=戦闘中、1=敗北、2=勝利、3=一定ラウンド経過、逃げ切った(引き分け)) (仮)
    public static int remainingTime;
    void Start()
    {
        StartCoroutine(StartGame());
    }

    void Update()
    {
        // 勝敗を判定
        switch (isWin)
        {
            case 1:
                Debug.Log("ゲームオーバー！");
                FadeManager.Instance.LoadScene("Result", 0.3f);
                break;
            case 2:
                Debug.Log("勝利！");
                FadeManager.Instance.LoadScene("Result", 0.3f);
                break;
            case 3:
                Debug.Log("引き分け");
                FadeManager.Instance.LoadScene("Result", 0.3f);
                break;
        }
    }

    void Awake()
    {
        // infoObjectとinfoTextがnullの場合は初期化
        if (infoObject == null)
        {
            infoObject = GameObject.Find("InfoObject"); // シーン内のオブジェクトを探して設定
        }

        if (infoText == null)
        {
            infoText = infoObject.GetComponentInChildren<Text>(); // infoObjectの子にTextコンポーネントを取得
        }
    }

    IEnumerator StartGame()
    {
        gameStart.SetActive(true);
        yield return new WaitForSeconds(3.0f);  // 3秒待機
        gameStart.SetActive(false);

        while (round <= 3)  // 1～3ラウンド
        {
            bool isExistFlask =IsExistFlask();

            while (IsExistFlask())
            {
                if (isExistFlask)
                {
                    yield return StartCoroutine(PlayerTurn()); // プレイヤーターン

                    if (!IsExistFlask()) // フラスコがなくなったら敵に切り替え
                    {
                        CameraChanger.CameraChange();
                        break;
                    }
                }
                yield return StartCoroutine(EnemyTurn()); // 敵ターン
                roop++;
            }

            // **ラウンドのリセット処理**
            ResetFlaskStatus();
            Debug.Log($"ラウンド {round} 終了");
            round++; // ラウンドを進める

            string roundName = "1st";
            switch(round)
            {
                case 1:
                    roundName = "1st"; break;
                case 2:
                    roundName = "2nd"; break;
                case 3:
                    roundName = "Final"; break;
                default:
                    break;
            }

            yield return new WaitForSeconds(1);
            StartCoroutine(InfoDisplay($"- {roundName} Round -", 4));
            yield return new WaitForSeconds(4);
            Debug.Log($"Displaying round info: - {roundName} Round -");
        }

        // 3ラウンド終了時の動作
        Debug.Log("リザルト画面に移動");
        isWin = 3;  // 逃げ切った=引き分け
        FadeManager.Instance.LoadScene("Result", 0.5f);
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
        StartCoroutine(InfoDisplay("- Your Turn -", 1));

        timerText.SetActive(true);
        remainingTime = 10; // 10秒カウントダウン

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
        isPlayerTurn = false;
        isEnemyTurn = true;
    }

    IEnumerator EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("敵のターン");
        CameraChanger.CameraChange();
        yield return new WaitForSeconds(1);
        StartCoroutine(InfoDisplay("- Enemy's Turn -", 1));
        yield return new WaitForSeconds(2);
        isEnemyTurn = true;
        isPlayerTurn = true;
    }

    // **フラスコをリセットするメソッド**
    void ResetFlaskStatus()
    {
        for (int i = 0; i < 8; i++)
        {
            LifeManager.flaskStatus[i] = Random.Range(0, LifeManager.itemNumber);
            LifeManager.flaskArray[i].SetActive(true);
        }
    }

    
    public static IEnumerator InfoDisplay(string s, float x)
    {
        infoText.text = s;
        infoObject.SetActive(true);
        yield return new WaitForSeconds(x);
        infoObject.SetActive(false);
    }

    public static void ResetGame()
    {
        GameManager.isWin = 0;
        LifeManager.myLifePoint = 4;
        LifeManager.enemyLifePoint = 4;
        GameManager.round = 1;
        GameManager.roop = 0;
    }
}
