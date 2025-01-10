using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public int round = 1;   // 3���E���h�܂�
    public int roop = 0;    // ���[�v�A�X�R�A�v�Z�p
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject timerText;
    public Text countdownText; // �J�E���g�_�E���p
    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        gameStart.SetActive(true);
        yield return new WaitForSeconds(3.0f);  // 3�b�ҋ@
        gameStart.SetActive(false);

        while (round <= 3)  // 1�`3���E���h
        {
            while (IsExistFlask())
            {
                yield return StartCoroutine(PlayerTurn());

                if (!IsExistFlask())
                {
                    CameraChanger.CameraChange();
                    break;
                }

                yield return StartCoroutine(EnemyTurn());
                roop++;
            }

            for (int i = 0; i < 8; i++)
            {
                LifeManager.flaskStatus[i] = Random.Range(0, LifeManager.itemNumber);
                LifeManager.flaskArray[i].SetActive(true);
            }
            Debug.Log($"���E���h {round} �I��");
            round++; // ���E���h��i�߂�
        }

        // 3���E���h�I�����̓��쏑��
    }

    // �Տ�Ƀt���X�R���c���Ă��邩���ׂ�
    bool IsExistFlask()
    {
        for (int i = 0; i < 8; i++)
        {
            if (LifeManager.flaskStatus[i] != 5)
            {
                return true; // �t���X�R�����݂���
            }
        }
        return false;
    }

    IEnumerator PlayerTurn()
    {
        isPlayerTurn = true;
        Debug.Log("�v���C���[�̃^�[��");
        CameraChanger.CameraChange();

        timerText.SetActive(true);
        int remainingTime = 10; // 10�b�J�E���g�_�E��

        while (remainingTime > 0)
        {
            if (!isPlayerTurn)
            {
                Debug.Log("�v���C���[�̃^�[���I��");
                timerText.SetActive(false);
                yield break; // �����I��
            }
            countdownText.text = remainingTime.ToString(); // UI�ɕ\��
            yield return new WaitForSeconds(1f); // 1�b�ҋ@
            remainingTime--;
        }

        countdownText.text = "TimeUp"; // 0�b�Ń��b�Z�[�W��\��
        Debug.Log("���Ԑ؂�");
        timerText.SetActive(false);
    }

    IEnumerator EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("�G�̃^�[��");
        CameraChanger.CameraChange();
        // �G�̃A�N�V����������
        yield return new WaitForSeconds(5.0f);   // 5�b�ҋ@
    }
}
