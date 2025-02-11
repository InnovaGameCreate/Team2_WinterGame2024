using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public static bool isPlayerTurn = false;
    public static int round = 1;   // 3ラウンドまで
    public static int roop = 0;    // ループ、スコア計算用
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject timerText;
    public Text countdownText; // カウントダウン用
    public static GameObject infoObject; // 進行通知用
    public static Text infoText; // 進行通知用
    public static int isWin = 0;   // 勝利判定用(0=戦闘中、1=敗北、2=勝利、3=一定ラウンド経過、逃げ切った(引き分け)) (仮)
=======
    // ラウンド・ループ設定
    private int totalRounds = 5;
    private int currentRound = 1;
    private int loopCount = 0;

    /// 勝敗状態　0: 戦闘中, 1: 敗北, 2: 勝利, 3: 引き分け
    public static int GameResult;

    [SerializeField] private LifeManager lifeManager;
    [SerializeField] private FlaskManager flaskManager;
    // プレイヤー操作用のスクリプトを GameManager から参照
    [SerializeField] private PlayerAction playerAction;

>>>>>>> Stashed changes
    void Start()
    {
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if (GameResult != 0)
        {
            Debug.Log("ゲーム終了 判定:" + GameResult);
            FadeManager.Instance.LoadScene("Result", 0.3f);
        }
    }

    IEnumerator StartGame()
    {
        while (currentRound <= totalRounds)
        {
            yield return StartCoroutine(RunRound());
            if (GameResult != 0)
                break;

            // ラウンド終了時：フラスコ状態をリセット
            flaskManager.ResetFlasks();
            Debug.Log($"ラウンド {currentRound} 終了");
            currentRound++;

            // 次ラウンド開始前に、カメラがプレイヤー用に完全に切り替わるまで待機
            yield return CameraChanger.SetPlayerTurnCameraCoroutine();
        }

        // 全ラウンド終了時は引き分け（逃げ切り）とする
        SetGameResult(3);
    }

    IEnumerator RunRound()
    {
        // 例：フラスコが残っている間、プレイヤーと敵が交互にターンを繰り返す
        while (flaskManager.number > 0)
        {
            yield return StartCoroutine(PlayerTurn());
            if (flaskManager.number == 0) break;
            yield return StartCoroutine(EnemyTurn());
            loopCount++;
        }
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("プレイヤーのターン開始");
        yield return CameraChanger.SetPlayerTurnCameraCoroutine();

<<<<<<< Updated upstream
        timerText.SetActive(true);
        int remainingTime = 10; // 10秒カウントダウン
=======
        // 必要なら、プレイヤー操作を有効にする（例：内部フラグのリセットなど）
        playerAction.EnableAction();
>>>>>>> Stashed changes

        // プレイヤー操作の完了を待つためのフラグ
        bool turnCompleted = false;

        // イベントの登録（PlayerAction.cs 側で、操作完了時に OnPlayerTurnCompleted イベントを発行する）
        System.Action onTurnComplete = () => { turnCompleted = true; };
        playerAction.OnPlayerTurnCompleted += onTurnComplete;

        // プレイヤーの選択（クリック＋ボタン操作）が完了するまで待機
        while (!turnCompleted)
        {
            yield return null;
        }

<<<<<<< Updated upstream
        countdownText.text = "TimeUp"; // 0秒でメッセージを表示
        Debug.Log("時間切れ");
        timerText.SetActive(false);
=======
        // イベント登録解除
        playerAction.OnPlayerTurnCompleted -= onTurnComplete;

        Debug.Log("プレイヤーのターン終了");
        // ※ 必要なら、選択結果に応じた追加処理をここで行う
>>>>>>> Stashed changes
    }

    IEnumerator EnemyTurn()
    {
<<<<<<< Updated upstream
        isPlayerTurn = false;
        Debug.Log("敵のターン");
        CameraChanger.CameraChange();
        yield return new WaitForSeconds(1);
        StartCoroutine(InfoDisplay("- Enemy's Turn -", 1));
        // 敵のアクションを書く
        yield return new WaitForSeconds(4.0f);   // 待機
=======
        Debug.Log("敵のターン開始");
        yield return CameraChanger.SetEnemyTurnCameraCoroutine();
        // TODO: 敵ターンのロジックを実装
        yield return new WaitForSeconds(2f);
>>>>>>> Stashed changes
    }

    public void SetGameResult(int result)
    {
        GameResult = result;
    }

    public void ResetGame()
    {
        GameResult = 0;
        currentRound = 1;
        loopCount = 0;
        lifeManager.ResetLifes();
    }
}
