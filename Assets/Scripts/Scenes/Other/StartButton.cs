using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameManager gameManager;
    // ボタンが押されたときの処理
    public void OnStartButtonClicked()
    {
        Debug.Log("ゲームをリセットしてタイトルに戻ります");
        // まずゲームリセットを行う
        gameManager.ResetGame();
        // その後、シーン遷移を行う
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
