using System.Collections;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [Header("カメラ参照")]
    [Tooltip("実際に動かすカメラ")]
    [SerializeField] private Camera mainCamera;

    [Header("ターゲットTransform")]
    [Tooltip("敵ターン時の正面ビューのターゲットTransform")]
    [SerializeField] private Transform mainViewTarget;
    [Tooltip("自分のターン時のアイテム選択ビューのターゲットTransform")]
    [SerializeField] private Transform chooseViewTarget;

    [Header("移動設定")]
    [Tooltip("カメラ移動にかかる時間")]
    [SerializeField] private float transitionDuration = 1.0f;

    private static CameraChanger instance;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 自分のターンに対応するカメラへ移動する（アイテム選択ビュー）
    /// </summary>
    public static IEnumerator SetPlayerTurnCameraCoroutine()
    {
        if (instance != null)
        {
            yield return instance.StartCoroutine(instance.SmoothTransition(instance.chooseViewTarget));
        }
    }

    /// <summary>
    /// 敵のターンに対応するカメラへ移動する（正面ビュー）
    /// </summary>
    public static IEnumerator SetEnemyTurnCameraCoroutine()
    {
        if (instance != null)
        {
            yield return instance.StartCoroutine(instance.SmoothTransition(instance.mainViewTarget));
        }
    }

    /// <summary>
    /// 指定したターゲットTransformまで滑らかに移動・回転するコルーチン
    /// </summary>
    private IEnumerator SmoothTransition(Transform targetView)
    {
        float elapsedTime = 0f;
        Vector3 startPos = mainCamera.transform.position;
        Quaternion startRot = mainCamera.transform.rotation;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            mainCamera.transform.position = Vector3.Lerp(startPos, targetView.position, t);
            mainCamera.transform.rotation = Quaternion.Slerp(startRot, targetView.rotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // 補間終了時に完全にターゲットに合わせる
        mainCamera.transform.position = targetView.position;
        mainCamera.transform.rotation = targetView.rotation;
    }
}
