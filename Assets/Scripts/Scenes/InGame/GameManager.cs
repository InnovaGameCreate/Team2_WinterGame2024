using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public int round = 1;   // 3���E���h�܂�
    public int roop = 0;    // ���[�v�A�X�R�A�v�Z�p
    [SerializeField] private GameObject gameStart;

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

                if (!IsExistFlask()) break;

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

        float elapsedTime = 0f;
        float waitTime = 10.0f;

        while (elapsedTime < waitTime)
        {
            if (!isPlayerTurn)
            {
                yield break; // �����I��
            }

            yield return null; // 1�t���[���ҋ@
            elapsedTime += Time.deltaTime;
        }
    }

    IEnumerator EnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("�G�̃^�[��");
        CameraChanger.CameraChange();
        yield return new WaitForSeconds(5.0f);   // 5�b�ҋ@
    }
}
