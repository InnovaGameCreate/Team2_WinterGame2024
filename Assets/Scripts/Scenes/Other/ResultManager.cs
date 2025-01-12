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
    private bool messageDisplayed = false; // ��x�������s���邽�߂̃t���O

    void Awake()
    {
        // �V�[��������x�����擾
        currentSceneName = SceneManager.GetActiveScene().name;

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
        // "Result" �V�[���ȊO�ł͉������Ȃ�
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
        // "Result" �V�[���ȊO�����[�h���ꂽ�ꍇ�� isWin �����Z�b�g
        if (loadedScene.name != "Result")
        {
            GameManager.isWin = 0;
        }
    }

    void OnDestroy()
    {
        // �C�x���g�o�^������
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
