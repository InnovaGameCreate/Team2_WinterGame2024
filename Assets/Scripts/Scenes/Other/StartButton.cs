using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameManager gameManager;
    // �{�^���������ꂽ�Ƃ��̏���
    public void OnStartButtonClicked()
    {
        Debug.Log("�Q�[�������Z�b�g���ă^�C�g���ɖ߂�܂�");
        // �܂��Q�[�����Z�b�g���s��
        gameManager.ResetGame();
        // ���̌�A�V�[���J�ڂ��s��
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
