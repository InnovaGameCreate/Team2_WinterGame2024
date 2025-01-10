using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
    public static int itemNumber = 4;
    // 0...���A1...�ŁA2...�A�C�e���A5...�t���X�R�����݂��Ȃ�

    public float distance = 100f;

    public GameObject GiveButton;
    public GameObject GetButton;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8 ; i++)
        {
            flaskStatus[i] = Random.Range(0, itemNumber - 1);
            flaskArray[i] = GameObject.Find($"flask{i + 1}"); // �t���X�R���V�[��������擾
        }
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

                        // ���ނ����܂��邩�̏�������ǉ�

                        if (flaskStatus[flaskNumber - 1] == 1 && myLifePoint > 0)
                        {
                            Debug.Log("�ł�����");
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;
                            myLifeArray[myLifePoint - 1].SetActive(false);
                            myLifePoint--;
                            if (myLifePoint <= 0)
                            {
                                Debug.Log("�Q�[���I�[�o�[�I");
                                SceneManager.LoadScene("Result");
                            }
                        }

                        else if (flaskStatus[flaskNumber - 1] == 0)
                        {
                            Debug.Log("��������");
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;
                        }

                        else if (flaskStatus[flaskNumber - 1] == 2)
                        {
                            Debug.Log("�����_������1����");
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;
                        }

                        else if (flaskStatus[flaskNumber - 1] == 3)
                        {
                            Debug.Log("�����_������2����");
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;

                        }

                        GameManager.isPlayerTurn = false;
                    }

                }
            }
        }
    }

    /*
    public void OnPointerClick(PointerEventData eventData)
    {
        print($"{name}���N���b�N����");

        CameraChanger.CameraChange();
    }
    */
}
