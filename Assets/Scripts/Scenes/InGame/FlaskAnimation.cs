using UnityEngine;

public class FlaskAnimation : MonoBehaviour
{
    private Vector3 firstPosition;

    void Start()
    {
        firstPosition = transform.position;
    }

    void Update()
    {
        transform.position = firstPosition;
    }

    // �}�E�X�J�[�\�����Ώۂɏ�����Ƃ��̏���
    private void OnMouseEnter()
    {
        transform.position = firstPosition + new Vector3(0, 3, 0);
    }

    // �}�E�X�J�[�\�����Ώۂ��痣�ꂽ�Ƃ��̏���
    private void OnMouseExit()
    {
        transform.position = firstPosition;
    }
}
