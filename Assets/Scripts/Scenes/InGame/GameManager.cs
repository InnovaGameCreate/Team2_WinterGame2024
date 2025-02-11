using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public static bool isPlayerTurn = false;
    public static int round = 1;   // 3���E���h�܂�
    public static int roop = 0;    // ���[�v�A�X�R�A�v�Z�p
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject timerText;
    public Text countdownText; // �J�E���g�_�E���p
    public static GameObject infoObject; // �i�s�ʒm�p
    public static Text infoText; // �i�s�ʒm�p
    public static int isWin = 0;   // ��������p(0=�퓬���A1=�s�k�A2=�����A3=��胉�E���h�o�߁A�����؂���(��������)) (��)
=======
    // ���E���h�E���[�v�ݒ�
    private int totalRounds = 5;
    private int currentRound = 1;
    private int loopCount = 0;

    /// ���s��ԁ@0: �퓬��, 1: �s�k, 2: ����, 3: ��������
    public static int GameResult;

    [SerializeField] private LifeManager lifeManager;
    [SerializeField] private FlaskManager flaskManager;
    // �v���C���[����p�̃X�N���v�g�� GameManager ����Q��
    [SerializeField] private PlayerAction playerAction;

>>>>>>> Stashed changes
    void Start()
    {
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if (GameResult != 0)
        {
            Debug.Log("�Q�[���I�� ����:" + GameResult);
            FadeManager.Instance.LoadScene("Result", 0.3f);
        }
    }

    IEnumerator StartGame()
    {
        while (currentRound <= totalRounds)
        {
            yield return StartCoroutine(RunRound());
            if (GameResult != 0)
                break;

            // ���E���h�I�����F�t���X�R��Ԃ����Z�b�g
            flaskManager.ResetFlasks();
            Debug.Log($"���E���h {currentRound} �I��");
            currentRound++;

            // �����E���h�J�n�O�ɁA�J�������v���C���[�p�Ɋ��S�ɐ؂�ւ��܂őҋ@
            yield return CameraChanger.SetPlayerTurnCameraCoroutine();
        }

        // �S���E���h�I�����͈��������i�����؂�j�Ƃ���
        SetGameResult(3);
    }

    IEnumerator RunRound()
    {
        // ��F�t���X�R���c���Ă���ԁA�v���C���[�ƓG�����݂Ƀ^�[�����J��Ԃ�
        while (flaskManager.number > 0)
        {
            yield return StartCoroutine(PlayerTurn());
            if (flaskManager.number == 0) break;
            yield return StartCoroutine(EnemyTurn());
            loopCount++;
        }
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("�v���C���[�̃^�[���J�n");
        yield return CameraChanger.SetPlayerTurnCameraCoroutine();

<<<<<<< Updated upstream
        timerText.SetActive(true);
        int remainingTime = 10; // 10�b�J�E���g�_�E��
=======
        // �K�v�Ȃ�A�v���C���[�����L���ɂ���i��F�����t���O�̃��Z�b�g�Ȃǁj
        playerAction.EnableAction();
>>>>>>> Stashed changes

        // �v���C���[����̊�����҂��߂̃t���O
        bool turnCompleted = false;

        // �C�x���g�̓o�^�iPlayerAction.cs ���ŁA���슮������ OnPlayerTurnCompleted �C�x���g�𔭍s����j
        System.Action onTurnComplete = () => { turnCompleted = true; };
        playerAction.OnPlayerTurnCompleted += onTurnComplete;

        // �v���C���[�̑I���i�N���b�N�{�{�^������j����������܂őҋ@
        while (!turnCompleted)
        {
            yield return null;
        }

<<<<<<< Updated upstream
        countdownText.text = "TimeUp"; // 0�b�Ń��b�Z�[�W��\��
        Debug.Log("���Ԑ؂�");
        timerText.SetActive(false);
=======
        // �C�x���g�o�^����
        playerAction.OnPlayerTurnCompleted -= onTurnComplete;

        Debug.Log("�v���C���[�̃^�[���I��");
        // �� �K�v�Ȃ�A�I�����ʂɉ������ǉ������������ōs��
>>>>>>> Stashed changes
    }

    IEnumerator EnemyTurn()
    {
<<<<<<< Updated upstream
        isPlayerTurn = false;
        Debug.Log("�G�̃^�[��");
        CameraChanger.CameraChange();
        yield return new WaitForSeconds(1);
        StartCoroutine(InfoDisplay("- Enemy's Turn -", 1));
        // �G�̃A�N�V����������
        yield return new WaitForSeconds(4.0f);   // �ҋ@
=======
        Debug.Log("�G�̃^�[���J�n");
        yield return CameraChanger.SetEnemyTurnCameraCoroutine();
        // TODO: �G�^�[���̃��W�b�N������
        yield return new WaitForSeconds(2f);
>>>>>>> Stashed changes
    }

    public void SetGameResult(int result)
    {
        GameResult = result;
    }

    public void ResetGame()
    {
        GameResult = 0;
        currentRound = 1;
        loopCount = 0;
        lifeManager.ResetLifes();
    }
}
