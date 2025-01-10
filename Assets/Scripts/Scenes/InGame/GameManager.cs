using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerTurn = false;
    public int round = 1;   // 3���E���h�܂�
    public int roop = 0;    // ���[�v�A�X�R�A�v�Z�p
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject timerText;
    public Text countdownText; // �J�E���g�_�E���p
    public static GameObject infoObject; // �i�s�ʒm�p
    public static Text infoText; // �i�s�ʒm�p
    void Start()
    {
        StartCoroutine(StartGame());
    }

    void Awake()
    {
        // infoObject��infoText��null�̏ꍇ�͏�����
        if (infoObject == null)
        {
            infoObject = GameObject.Find("InfoObject"); // �V�[�����̃I�u�W�F�N�g��T���Đݒ�
        }

        if (infoText == null)
        {
            infoText = infoObject.GetComponentInChildren<Text>(); // infoObject�̎q��Text�R���|�[�l���g���擾
        }
    }

    IEnumerator StartGame()
    {
        gameStart.SetActive(true);
        yield return new WaitForSeconds(3.0f);  // 3�b�ҋ@
        gameStart.SetActive(false);

        while (round <= 3)  // 1�`3���E���h
        {
            bool isExistFlask =IsExistFlask();

            while (IsExistFlask())
            {
                if (isExistFlask)
                {
                    yield return StartCoroutine(PlayerTurn()); // �v���C���[�^�[��

                    if (!IsExistFlask()) // �t���X�R���Ȃ��Ȃ�����G�ɐ؂�ւ�
                    {
                        CameraChanger.CameraChange();
                        break;
                    }
                }

                yield return StartCoroutine(EnemyTurn()); // �G�^�[��
                roop++;
            }

            // **���E���h�̃��Z�b�g����**
            ResetFlaskStatus();
            Debug.Log($"���E���h {round} �I��");
            round++; // ���E���h��i�߂�

            string roundName = "����w";
            switch(round)
            {
                case 1:
                    roundName = "1st"; break;
                case 2:
                    roundName = "2nd"; break;
                case 3:
                    roundName = "Final"; break;
                default:
                    break;
            }

            yield return new WaitForSeconds(1);
            StartCoroutine(InfoDisplay($"-{roundName} Round -", 4));
            yield return new WaitForSeconds(4);
            Debug.Log($"Displaying round info: -{roundName} Round -");
        }

        // 3���E���h�I�����̓���
        Debug.Log("���U���g��ʂɈړ�");
        FadeManager.Instance.LoadScene("Result", 0.5f);
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
        StartCoroutine(InfoDisplay("- Your Turn -", 1));

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
        yield return new WaitForSeconds(1);
        StartCoroutine(InfoDisplay("- Enemy's Turn -", 1));
        // �G�̃A�N�V����������
        yield return new WaitForSeconds(4.0f);   // �ҋ@
    }

    // **�t���X�R�����Z�b�g���郁�\�b�h**
    void ResetFlaskStatus()
    {
        for (int i = 0; i < 8; i++)
        {
            LifeManager.flaskStatus[i] = Random.Range(0, LifeManager.itemNumber);
            LifeManager.flaskArray[i].SetActive(true);
        }
    }

    
    public static IEnumerator InfoDisplay(string s, float x)
    {
        infoText.text = s;
        infoObject.SetActive(true);
        yield return new WaitForSeconds(x);
        infoObject.SetActive(false);
    }
}
