using System.Collections;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [Header("�J�����Q��")]
    [Tooltip("���ۂɓ������J����")]
    [SerializeField] private Camera mainCamera;

    [Header("�^�[�Q�b�gTransform")]
    [Tooltip("�G�^�[�����̐��ʃr���[�̃^�[�Q�b�gTransform")]
    [SerializeField] private Transform mainViewTarget;
    [Tooltip("�����̃^�[�����̃A�C�e���I���r���[�̃^�[�Q�b�gTransform")]
    [SerializeField] private Transform chooseViewTarget;

    [Header("�ړ��ݒ�")]
    [Tooltip("�J�����ړ��ɂ����鎞��")]
    [SerializeField] private float transitionDuration = 1.0f;

    private static CameraChanger instance;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// �����̃^�[���ɑΉ�����J�����ֈړ�����i�A�C�e���I���r���[�j
    /// </summary>
    public static IEnumerator SetPlayerTurnCameraCoroutine()
    {
        if (instance != null)
        {
            yield return instance.StartCoroutine(instance.SmoothTransition(instance.chooseViewTarget));
        }
    }

    /// <summary>
    /// �G�̃^�[���ɑΉ�����J�����ֈړ�����i���ʃr���[�j
    /// </summary>
    public static IEnumerator SetEnemyTurnCameraCoroutine()
    {
        if (instance != null)
        {
            yield return instance.StartCoroutine(instance.SmoothTransition(instance.mainViewTarget));
        }
    }

    /// <summary>
    /// �w�肵���^�[�Q�b�gTransform�܂Ŋ��炩�Ɉړ��E��]����R���[�`��
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
        // ��ԏI�����Ɋ��S�Ƀ^�[�Q�b�g�ɍ��킹��
        mainCamera.transform.position = targetView.position;
        mainCamera.transform.rotation = targetView.rotation;
    }
}
