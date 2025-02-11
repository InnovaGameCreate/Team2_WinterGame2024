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

    // �Œ�l�ł͂Ȃ� Update ���Ō��݂̃V�[�����m�F����̂ŕs�v
    // private string currentSceneName;
    private bool messageDisplayed = false; // ��x�������s���邽�߂̃t���O

    void Awake()
    {
        // �Œ�̃V�[�����擾�͍폜���邩�A�K�v�Ȃ� OnSceneLoaded �ōX�V����
        // currentSceneName = SceneManager.GetActiveScene().name;

        // resultText��Inspector�Őݒ肳��Ă��Ȃ���΁A�����擾
        if (resultText == null && resultObject != null)
        {
            resultText = resultObject.GetComponentInChildren<Text>();
        }

        // Null�`�F�b�N
        if (resultObject == null || resultText == null || winMessage == null || loseMessage == null)
        {
            Debug.LogError("�K�v�ȃI�u�W�F�N�g���ݒ肳��Ă��܂���I");
        }

        // �V�[�����[�h���̃C�x���g�o�^
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        // ���݂̃V�[�����𖈉�擾���ă`�F�b�N����
        if (SceneManager.GetActiveScene().name != "Result" || messageDisplayed)
            return;

        // GameDirector �̃C���X�^���X�o�R�ŏ��s���ʂ��擾����
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
                // ���b�Z�[�W���\���i�ʏ�͕s�v�j
                HideMessages();
                break;
        }
    }

    private void DisplayResult(GameObject messageObject, string message)
    {
        messageDisplayed = true; // �t���O�𗧂Ăčĕ\����h��
        HideMessages(); // ���̃��b�Z�[�W���\��
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
        // "Result" �V�[���ȊO�����[�h���ꂽ�ꍇ�� GameDirector �̏��s��Ԃ����Z�b�g
        if (loadedScene.name != "Result")
        {
            gameManager.SetGameResult(0);
            // ���b�Z�[�W�\���p�̃t���O�����Z�b�g�i�K�v�Ȃ�j
            messageDisplayed = false;
        }
    }

    void OnDestroy()
    {
        // �C�x���g�o�^������
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
