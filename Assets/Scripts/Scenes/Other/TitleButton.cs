using UnityEngine;

public class TitleButton : MonoBehaviour
{
    GameManager gameManager;
    // �^�C�g���V�[���֖߂�{�^���̃N���b�N����
    public void TitleStartClick()
    {
        Debug.Log("�^�C�g����ʂɖ߂�O�ɃQ�[�������Z�b�g����");
        // �܂��Q�[�����Z�b�g���s��
        gameManager.ResetGame();
        // ���̌�A�^�C�g���V�[���֑J�ڂ���
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
