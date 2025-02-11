using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskManager : MonoBehaviour
{
    // ���݃A�N�e�B�u�ȃt���X�R�̌��iResetFlasks() ���Ō���j
    public int number;
    // �C���X�y�N�^����t���X�R�ƂȂ� GameObject ��8�o�^�i�e GameObject �ɂ� Flask �R���|�[�l���g��t�^�j
    [SerializeField] public GameObject[] flaskArray = new GameObject[8];

    void Start()
    {
        ResetFlasks();
    }

    public void ResetFlasks()
    {
        // �@ ���ׂẴt���X�R���A�N�e�B�u�ɂ���
        foreach (GameObject flask in flaskArray)
        {
            flask.SetActive(false);
        }

        // �A �����_���Ȍ��i5�`8�j���A�N�e�B�u�ɂ���
        number = Random.Range(5, 9);
        List<int> indices = new List<int>();
        while (indices.Count < number)
        {
            int randIndex = Random.Range(0, flaskArray.Length);
            if (!indices.Contains(randIndex))
            {
                indices.Add(randIndex);
                GameObject flaskObj = flaskArray[randIndex];
                flaskObj.SetActive(true);
                // �B �A�N�e�B�u�ɂȂ����t���X�R�̒��g�����肷��
                Flask flaskComp = flaskObj.GetComponent<Flask>();
                if (flaskComp != null)
                {
                    flaskComp.DetermineContents();
                }
                else
                {
                    Debug.LogWarning("Flask �R���|�[�l���g�� " + flaskObj.name + " �ɑ��݂��܂���I");
                }
            }
        }
    }
}
