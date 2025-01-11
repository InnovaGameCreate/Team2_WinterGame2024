using UnityEngine;
using UnityEngine.UI;
using System;

public class Datetext : MonoBehaviour
{
    //�e�L�X�gUI���h���b�O&�h���b�v
    [SerializeField] Text DateTimeText;

    //DateTime���g�����ߕϐ���ݒ�
    DateTime TodayNow;

    void Update()
    {
        //���Ԃ��擾
        TodayNow = DateTime.Now;

        //�e�L�X�gUI�Ɍ��E���E�N��\��������i�C�O���j
        DateTimeText.text = TodayNow.Month.ToString() + "/" + TodayNow.Day.ToString() + "/" + TodayNow.Year.ToString();
    }
}