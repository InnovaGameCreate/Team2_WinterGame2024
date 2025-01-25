using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
        [Tooltip("�����̗̑�")]
        public GameObject[] myLifeArray = new GameObject[4];
        public static int myLifePoint = 4;

        [Tooltip("�G�̗̑�")]
        public GameObject[] enemyLifeArray = new GameObject[4];
        public static int enemyLifePoint = 4;

        [Tooltip("�t���X�R")]
        public static GameObject[] flaskArray = new GameObject[8];
        public static int[] flaskStatus = new int[8];
        public static int itemNumber = 3;
        // 0=���A1=�ŁA2=�����_�����ʁA5=�t���X�R�����݂��Ȃ�

        public float distance = 100f;
        public static int which = 0; // 1 = player, 2 = enemy

        public GameObject GiveButton;     // ����Ɉ��܂���{�^��
        public GameObject GetButton;      // ���������ރ{�^��
        public static GameObject[] itemArray = new GameObject[3];        // �A�C�e��

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                flaskStatus[i] = Random.Range(0, itemNumber);   // �����_���Ɍ��ʊi�[
                flaskArray[i] = GameObject.Find($"flask{i + 1}"); // �t���X�R���V�[��������擾
            }

            which = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.isPlayerTurn)
            {
                // ���N���b�N���擾
                if (Input.GetMouseButtonDown(0))
                {
                    // �N���b�N�����X�N���[�����W��ray�ɕϊ�
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    // Ray�̓��������I�u�W�F�N�g�̏����i�[����
                    RaycastHit hit = new RaycastHit();
                    // �I�u�W�F�N�g��ray������������
                    if (Physics.Raycast(ray, out hit, distance))
                    {
                        // ray�����������I�u�W�F�N�g�̖��O���擾
                        string objectName = hit.collider.gameObject.name;
                        Debug.Log(objectName);

                    if (objectName.Contains("flask"))
                    {
                        char temp = objectName[5];
                        int flaskNumber = int.Parse(temp.ToString());
                        GameObject thatFlask = GameObject.Find($"flask{flaskNumber}");
                        Vector3 currentPosition = thatFlask.transform.position; // ���݂̍��W���擾
                        thatFlask.transform.position = new Vector3(currentPosition.x, currentPosition.y + 5, currentPosition.z); // y���W��3����

                        GiveButton.SetActive(true);
                        GetButton.SetActive(true);
                        StartCoroutine(ChooseFlask(flaskNumber));

                            thatFlask.transform.position = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z); // ���W��߂�
                            GiveButton.SetActive(false);
                            GetButton.SetActive(false);
                        }
                    }
                }
            }

            // �G�̃^�[��
            if(GameManager.isEnemyTurn)
            {
                int flaskNumber;
                do
                {
                    flaskNumber = Random.Range(1, 9);
                } while (flaskStatus[flaskNumber - 1] == 5);
                
                int temp = Random.Range(1, 6); // �G��L����
                if (temp ==  1)
                {
                    if (flaskStatus[flaskNumber - 1] == 1) which = 1; // ��
                    else which = 2;
                }
                else
                {
                    which = Random.Range(1, 3);
                }

                if (which == 1)
                {
                    MyFlaskResult(flaskNumber);
                }
                else if (which == 2)
                {
                    EnemyFlaskResult(flaskNumber);
                }

                GameManager.isEnemyTurn = false;
                which = 0;
            }

            // �s�k
            if (myLifePoint <= 0)
            {
                GameManager.isWin = 1;  // �s�k
            }

            // ����
            if (enemyLifePoint <= 0)
            {
                GameManager.isWin = 2;  // ����
            }
        }

        void MyFlaskResult(int flaskNumber)
        {
            if (flaskStatus[flaskNumber - 1] == 1 && myLifePoint > 0)
            {
                Debug.Log("�ł�����");
                StartCoroutine(GameManager.InfoDisplay("- Poison -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
                myLifeArray[myLifePoint - 1].SetActive(false);
                myLifePoint--;
            }

            else if (flaskStatus[flaskNumber - 1] == 0)
            {
                Debug.Log("��������");
                StartCoroutine(GameManager.InfoDisplay("- Water -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }

            // �������_������

            else if (flaskStatus[flaskNumber - 1] == 2)
            {
                Debug.Log("�����_�����ʔ���");
                StartCoroutine(GameManager.InfoDisplay("- Random Effect -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }
        }

        void EnemyFlaskResult(int flaskNumber)
        {
            if (flaskStatus[flaskNumber - 1] == 1 && enemyLifePoint > 0)
            {
                Debug.Log("�ł�����");
                StartCoroutine(GameManager.InfoDisplay("- Poison -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
                enemyLifeArray[enemyLifePoint - 1].SetActive(false);
                enemyLifePoint--;
            }

            else if (flaskStatus[flaskNumber - 1] == 0)
            {
                Debug.Log("��������");
                StartCoroutine(GameManager.InfoDisplay("- Water -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }

            // �������_������

            else if (flaskStatus[flaskNumber - 1] == 2)
            {
                Debug.Log("�����_�����ʔ���");
                StartCoroutine(GameManager.InfoDisplay("- Random Effect -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }
        }

    IEnumerator ChooseFlask(int flaskNumber)
    {

        which = 0;
        yield return new WaitUntil(() => which != 0);
        if (which == 1)
            {
                StartCoroutine(GameManager.InfoDisplay($"- You -", 3));
                MyFlaskResult(flaskNumber);
            }
            else if (which == 2)
            {
                StartCoroutine(GameManager.InfoDisplay($"- Enemy -", 3));
                EnemyFlaskResult(flaskNumber);
            }
        GameManager.isPlayerTurn = false;
        yield break;
    }
}
