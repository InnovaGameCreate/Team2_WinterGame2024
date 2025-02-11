<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
=======
>>>>>>> Stashed changes
using UnityEngine;

public class LifeManager : MonoBehaviour
{
<<<<<<< Updated upstream
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
    // 0=���A1=�ŁA2=�A�C�e���A5=�t���X�R�����݂��Ȃ�

    public float distance = 100f;

    public static GameObject GiveButton;     // ����Ɉ��܂���{�^��
    public static GameObject GetButton;      // ���������ރ{�^��
    public static GameObject[] itemArray = new GameObject[3];        // �A�C�e��

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8 ; i++)
        {
            flaskStatus[i] = Random.Range(0, itemNumber);   // �����_���Ɍ��ʊi�[
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

                        GameManager.isPlayerTurn = false;
                    }

                }
            }
        }

        // �s�k
        if(myLifePoint <= 0)
        {
            GameManager.isWin = 1;  // �s�k
        }

        // ����
        if(enemyLifePoint <= 0)
        {
            GameManager.isWin = 2;  // ����
=======
    int myLife;
    int enemyLife;
    [SerializeField] private int startingLife = 4;
    [SerializeField] private GameObject[] myLifeArray = new GameObject[4];
    [SerializeField] private GameObject[] enemyLifeArray = new GameObject[4];

    void Start()
    {
        myLife = startingLife;
        enemyLife = startingLife;
    }

    public void ApplyPlayerDamage(int amount)
    {
        myLife -= amount;
        Debug.Log($"Player takes {amount} damage. Remaining life: {myLife}");
        // �K�v�ɉ����� UI �X�V��s�k���������
    }

    public void ApplyPlayerHeal(int amount)
    {
        myLife += amount;
        Debug.Log($"Player heals {amount}. Life: {myLife}");
        // UI �X�V�Ȃ�
    }

    public void ApplyEnemyDamage(int amount)
    {
        enemyLife -= amount;
        Debug.Log($"Enemy takes {amount} damage. Remaining life: {enemyLife}");
        // UI �X�V�A�s�k����Ȃ�
    }

    public void ApplyEnemyHeal(int amount)
    {
        enemyLife += amount;
        Debug.Log($"Enemy heals {amount}. Life: {enemyLife}");
        // UI �X�V�Ȃ�
    }

    public void ResetLifes()
    {
        myLife = startingLife;
        enemyLife = startingLife;
        foreach (GameObject life in myLifeArray)
        {
            life.SetActive(true);
        }
        foreach (GameObject life in enemyLifeArray)
        {
            life.SetActive(true);
>>>>>>> Stashed changes
        }
    }
}
