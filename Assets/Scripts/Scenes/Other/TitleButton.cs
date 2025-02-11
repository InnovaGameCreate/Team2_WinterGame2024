using UnityEngine;

public class TitleButton : MonoBehaviour
{
    GameManager gameManager;
    // タイトルシーンへ戻るボタンのクリック処理
    public void TitleStartClick()
    {
        Debug.Log("タイトル画面に戻る前にゲームをリセットする");
        // まずゲームリセットを行う
        gameManager.ResetGame();
        // その後、タイトルシーンへ遷移する
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
