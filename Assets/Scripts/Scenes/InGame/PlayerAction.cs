using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [Header("Ray設定")]
    public float rayDistance = 100f;

    [Header("ボタン設定")]
    public GameObject giveButton;
    public GameObject getButton;

    [Header("ライフ管理")]
    [SerializeField] private LifeManager lifeManager;

    // プレイヤー操作完了時に発行するイベント（GameManagerで待機）
    public event System.Action OnPlayerTurnCompleted;

    // 内部状態管理用の変数
    private bool selectionMade = false;
    private string selectionResult = "";

    void Update()
    {
        // 左クリックでフラスコを選択する処理
        if (Input.GetMouseButtonDown(0))
        {
            ProcessPlayerClick();
        }
    }

    /// <summary>
    /// Raycastでフラスコを選択する処理
    /// </summary>
    private void ProcessPlayerClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            string objName = hit.collider.gameObject.name;
            if (objName.Contains("flask"))
            {
                int flaskNumber = int.Parse(objName.Replace("flask", ""));
                GameObject selectedFlask = hit.collider.gameObject;
                Vector3 originalPos = selectedFlask.transform.position;

                // 演出：フラスコを一時的に持ち上げる
                selectedFlask.transform.position += Vector3.up * 5f;

                // ボタンを表示
                giveButton.SetActive(true);
                getButton.SetActive(true);

                // 内部状態のリセット
                selectionMade = false;
                selectionResult = "";

                StartCoroutine(WaitForPlayerSelection(flaskNumber, selectedFlask, originalPos));
            }
        }
    }

    /// <summary>
    /// プレイヤーの選択完了を待機して、効果処理を実行する
    /// </summary>
    private IEnumerator WaitForPlayerSelection(int flaskNumber, GameObject selectedFlask, Vector3 originalPos)
    {
        while (!selectionMade)
        {
            yield return null;
        }

        // ボタン非表示、フラスコ位置を元に戻す
        giveButton.SetActive(false);
        getButton.SetActive(false);
        selectedFlask.transform.position = originalPos;

        // ここでフラスコの効果を適用する処理（例）
        Flask flaskComp = selectedFlask.GetComponent<Flask>();
        if (flaskComp != null)
        {
            if (selectionResult == "get")
            {
                Debug.Log($"プレイヤー：フラスコ {flaskNumber} を自分で飲む");
                // 自分で飲む効果処理
            }
            else if (selectionResult == "give")
            {
                Debug.Log($"プレイヤー：フラスコ {flaskNumber} を敵に渡す");
                // 敵に渡す効果処理
            }
        }
        else
        {
            Debug.LogWarning("選択したフラスコにFlaskコンポーネントがありません。");
        }

        // 操作完了イベントの発行
        OnPlayerTurnCompleted?.Invoke();
    }

    /// <summary>
    /// giveButtonのOnClickイベント用メソッド
    /// </summary>
    public void OnGiveButtonClicked()
    {
        selectionResult = "give";
        selectionMade = true;
    }

    /// <summary>
    /// getButtonのOnClickイベント用メソッド
    /// </summary>
    public void OnGetButtonClicked()
    {
        selectionResult = "get";
        selectionMade = true;
    }

    /// <summary>
    /// ゲームマネージャーから呼ばれる、操作開始時の初期化メソッド
    /// </summary>
    public void EnableAction()
    {
        // 内部状態の初期化など、必要な処理を記述
        selectionMade = false;
        selectionResult = "";
    }
}
