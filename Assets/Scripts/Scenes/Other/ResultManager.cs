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

    private string currentSceneName;
    private bool messageDisplayed = false; // 一度だけ実行するためのフラグ

    void Awake()
    {
        // シーン名を一度だけ取得
        currentSceneName = SceneManager.GetActiveScene().name;

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
        // "Result" シーン以外では何もしない
        if (currentSceneName != "Result" || messageDisplayed) return;

        switch (GameManager.isWin)
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
        StartCoroutine(resultDisplay(message));
    }

    private void HideMessages()
    {
        winMessage.SetActive(false);
        loseMessage.SetActive(false);
    }

    IEnumerator resultDisplay(string message)
    {
        resultText.text = message;
        resultObject.SetActive(true);
        yield return new WaitForSeconds(10);
        resultObject.SetActive(false);
    }

    private void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        // "Result" シーン以外がロードされた場合に isWin をリセット
        if (loadedScene.name != "Result")
        {
            GameManager.isWin = 0;
        }
    }

    void OnDestroy()
    {
        // イベント登録を解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
