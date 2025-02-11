using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private GameObject resultObject = null;
    [SerializeField] private Text resultText = null;
    [SerializeField] private GameObject winMessage = null;
    [SerializeField] private GameObject loseMessage = null;

    GameManager gameManager;

    // 固定値ではなく Update 内で現在のシーンを確認するので不要
    // private string currentSceneName;
    private bool messageDisplayed = false; // 一度だけ実行するためのフラグ

    void Awake()
    {
        // 固定のシーン名取得は削除するか、必要なら OnSceneLoaded で更新する
        // currentSceneName = SceneManager.GetActiveScene().name;

        // resultTextがInspectorで設定されていなければ、自動取得
        if (resultText == null && resultObject != null)
        {
            resultText = resultObject.GetComponentInChildren<Text>();
        }

        // Nullチェック
        if (resultObject == null || resultText == null || winMessage == null || loseMessage == null)
        {
            Debug.LogError("必要なオブジェクトが設定されていません！");
        }

        // シーンロード時のイベント登録
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        // 現在のシーン名を毎回取得してチェックする
        if (SceneManager.GetActiveScene().name != "Result" || messageDisplayed)
            return;

        // GameDirector のインスタンス経由で勝敗結果を取得する
        switch (GameManager.GameResult)
        {
            case 1:
                DisplayResult(loseMessage, "- GAME OVER -");
                break;

            case 2:
                DisplayResult(winMessage, "- YOU WIN -");
                break;

            case 3:
                DisplayResult(loseMessage, "- DRAW -");
                break;

            default:
                // メッセージを非表示（通常は不要）
                HideMessages();
                break;
        }
    }

    private void DisplayResult(GameObject messageObject, string message)
    {
        messageDisplayed = true; // フラグを立てて再表示を防ぐ
        HideMessages(); // 他のメッセージを非表示
        messageObject.SetActive(true);
        StartCoroutine(ResultDisplay(message));
    }

    private void HideMessages()
    {
        winMessage.SetActive(false);
        loseMessage.SetActive(false);
    }

    IEnumerator ResultDisplay(string message)
    {
        resultText.text = message;
        resultObject.SetActive(true);
        yield return new WaitForSeconds(3);
        resultObject.SetActive(false);
    }

    private void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        // "Result" シーン以外がロードされた場合に GameDirector の勝敗状態をリセット
        if (loadedScene.name != "Result")
        {
            gameManager.SetGameResult(0);
            // メッセージ表示用のフラグもリセット（必要なら）
            messageDisplayed = false;
        }
    }

    void OnDestroy()
    {
        // イベント登録を解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
